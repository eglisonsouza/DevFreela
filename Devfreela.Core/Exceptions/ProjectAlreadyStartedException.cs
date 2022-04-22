namespace Devfreela.Core.Exceptions
{
    internal class ProjectAlreadyStartedException : Exception
    {
        public ProjectAlreadyStartedException() : base("Project is already in Started status")
        {
        }
    }
}
