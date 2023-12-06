using Arkusnexus.StockTaking.API.Dtos;
using FluentValidation;

namespace Arkusnexus.StockTaking.API.DtosValidators
{
    public class DeviceItemDtoValidator : AbstractValidator<DeviceItemDto>
    {
        public DeviceItemDtoValidator() 
        {
            RuleFor(x => x.DeviceId).NotEmpty();
            RuleFor(x => x.Brand).NotEmpty().MaximumLength(150);
            RuleFor(x => x.Model).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}