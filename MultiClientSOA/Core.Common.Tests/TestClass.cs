using Core.Common.Core;
using FluentValidation;

namespace Core.Common.Tests
{
    public class TestClass : ObjectBase
    {
        string _Clean;
        public string Clean
        {
            get => _Clean;
            set
            {
                if (_Clean != value)
                {
                    _Clean = value;
                    OnPropertyChanged(() => Clean);
                }
                Validate();
            }
        }

        class TestValidator : AbstractValidator<TestClass>
        {
            public TestValidator()
            {
                RuleFor(obj => obj.Clean).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new TestValidator();
        }
    }
}
