using FluentValidation;
using FubuMVC.Core;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Runtime;

namespace Blog.Behaviors
{
    public class ValidationBehavior<T> : BasicBehavior where T: class
    {
        private readonly IJsonWriter _jsonWriter;
        private readonly IFubuRequest _request;
        private readonly IValidator<T> _validator;

        public ValidationBehavior(IJsonWriter jsonWriter, IFubuRequest request,
            IValidator<T> validator) : base(PartialBehavior.Ignored)
        {
            _jsonWriter = jsonWriter;
            _request = request;
            _validator = validator;
        }

        protected override DoNext performInvoke()
        {
            if (_validator == null) return DoNext.Continue;

            var validationResult = _validator.Validate(_request.Get<T>());

            if (validationResult.IsValid) return DoNext.Continue;

            _jsonWriter.Write(new
            {
                validationResult.Errors
            });
            return DoNext.Stop;
        }
    }
}