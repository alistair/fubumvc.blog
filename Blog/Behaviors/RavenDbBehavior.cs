using FubuMVC.Core.Behaviors;
using Raven.Client;

namespace Blog.Behaviors
{
    public class RavenDbBehavior : IActionBehavior
    {
        private readonly IDocumentSession _session;
        public IActionBehavior InsideBehavior { get; set; }

        public RavenDbBehavior(IDocumentSession session)
        {
            _session = session;
        }

        public void Invoke()
        {
            using(_session)
            {
                InsideBehavior.Invoke();
                _session.SaveChanges();
            }
        }

        public void InvokePartial()
        {
            InsideBehavior.InvokePartial();
        }
    }
}