using AutoMapper;
using PaymentSystemApi_v01.Contracts;
using PaymentSystemApi_v01.Core;
using PaymentSystemApi_v01.DTO;

namespace PaymentSystemApi_v01.Services
{
    public class MarchantsServices : IMarchantService
    {
        private readonly IMapper _mapper;
        public MarchantsServices(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
            SeedMarchant();
        }

        private void SeedMarchant()
        {
            if (!Context.Marchants.Any())
            {
                Context.Marchants.Add(new Marchant
                {   Id ="1",
                    MarchantNumber = "01234567891",
                    BusinessName = "wumi",
                    BusinessId = "+2348036266786",
                    ContactName = "Yusuf",
                    ContactSurname ="Yusuf",
                   AverageTransactionVolume = 1
                });
                Context.SaveChanges();
            }
            

        }

        public ApplicationDbContext Context { get; }



        public async Task<(bool successful, MarchantDto marchants, bool fail)> MarchantById(string id)
        {
            return await Task.FromResult((true, _mapper.Map<MarchantDto>(Context.Marchants.FirstOrDefault(x => x.Id == id)), false));
        }

        public async Task<(bool successful, IEnumerable<MarchantDto> marchants, bool fail)> Marchants()
        {
            var marchants = Context.Marchants;
            return await Task.FromResult((true, _mapper.Map<IEnumerable<MarchantDto>>(marchants), false));
        }

        public async Task<(bool successful, bool fail)> Marchant(MarchantDto input)
        {
             await Context.Marchants.AddAsync( _mapper.Map<Marchant>(input));
           var result= await Context.SaveChangesAsync();
            if (result > -1)
            { 
            
            return  await Task.FromResult((true, false));
            }
            return await Task.FromResult((false, true));

        }

    }
}
