using MauiSampleApp.Helpers;

namespace MauiSampleApp.ViewModels
{
    public class BaseViewModel : NotifyPropertyChangedBase
    {
        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);

        #region These methods will only work if there page is in NavigationPage
        public virtual void PagePushed(NavigationEventArgs e)
        {
            try
            {
                
            }
            catch (Exception exc)
            {
                //TraceHandler.Instance.ExceptionToTraceErrorLog(exc);
            }
        }

        public virtual void PagePopped(NavigationEventArgs e)
        {
            try
            {
                
            }
            catch (Exception exc)
            {
                //TraceHandler.Instance.ExceptionToTraceErrorLog(exc);
            }
        }
        #endregion
    }
}