using AutoMapper;

namespace Bread.Services
{
    public abstract class BreadService
    {
        public BreadService(IMapper mapper)
        {
            Mapper = mapper;
        }

        public IMapper Mapper { get; set; }
    }
}
