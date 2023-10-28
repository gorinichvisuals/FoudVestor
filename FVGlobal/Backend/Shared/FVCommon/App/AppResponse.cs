namespace FVCommon.App;

public class AppResponse : IEquatable<AppResponse>
{
    public int StatusCode { get; }
    public bool IsSucceed { get; }
    public string ErrorMessage { get; }

    protected AppResponse(int statusCode, bool isSuccess, string errorMessage)
    {
        StatusCode = statusCode;
        IsSucceed = isSuccess;
        ErrorMessage = errorMessage;
    }

    public static AppResponse<TResponse> Success<TResponse>(int statusCode, TResponse response)
    {
        return AppResponse<TResponse>.Success(statusCode, response);
    }

    public static AppResponse Success(int statusCode)
    {
        return new AppResponse(statusCode, true, null!);
    }

    public static AppResponse Fail(int statusCode, string errorMessage)
    {
        return new AppResponse(statusCode, false, errorMessage);
    }

    public override bool Equals(object? obj)
    {
        if (obj is AppResponse e)
        {
            return e.IsSucceed.Equals(IsSucceed);
        }

        return ReferenceEquals(this, obj);
    }

    public bool Equals(AppResponse? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return IsSucceed == other.IsSucceed && ErrorMessage == other.ErrorMessage;
    }

    public override int GetHashCode()
    {
        return (int)(IsSucceed.GetHashCode() ^ ErrorMessage?.GetHashCode()!);
    }

    public static bool operator ==(AppResponse left, AppResponse right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(AppResponse left, AppResponse right)
    {
        return !Equals(left, right);
    }

    public virtual object? GetResponse()
    {
        return null;
    }
}

public sealed class AppResponse<TResult> : AppResponse
{
    private TResult Result { get; }

    private AppResponse(bool isSuccess, string errorMessage, TResult result, int statusCode) : base(statusCode, isSuccess, errorMessage)
    {
        Result = result;
    }

    public new TResult? GetResponse()
    {
        return Result;
    }

    public static AppResponse<TResult> Success(int statusCode, TResult response)
    {
        return new AppResponse<TResult>(true, null!, response, statusCode);
    }

    public new static AppResponse<TResult> Fail(int statusCode, string errorMessage)
    {
        return new AppResponse<TResult>(false, errorMessage, default!, statusCode);
    }
}