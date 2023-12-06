using Arkusnexus.StockTaking.API.Dtos;
using FluentValidation;

namespace Arkusnexus.StockTaking.API.DtosValidators
{
    public class DeviceDtoValidator : AbstractValidator<DeviceDto>
    {
        public DeviceDtoValidator() 
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
        }
    }
}