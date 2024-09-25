namespace PeakPerformance.Application.BusinessLogic._Base;

public abstract class BaseHandlerProcess
{
    protected static bool TryRun(Action action, ILogger logger)
    {
        try
        {
            action();
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return false;
        }
    }

    protected static async Task<bool> TryRunAsync(Func<Task> action, ILogger logger)
    {
        try
        {
            await action();
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return false;
        }
    }

    protected static void CheckUserAuthorization(IIdentityUser user, params eSystemRole[] requiredRoles)
    {
        if (!user.IsAuthenticated || !user.HasRole([.. requiredRoles]))
        {
            throw new UnauthorizedAccessException();
        }
    }
}