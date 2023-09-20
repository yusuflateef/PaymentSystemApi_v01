using PaymentSystemApi_v01.DTO;

namespace PaymentSystemApi_v01.Contracts
{
    public interface IMarchantService
    {

        Task<(bool successful, bool fail)> Marchant(MarchantDto input);

        Task<(bool successful, IEnumerable<MarchantDto> marchants, bool fail)> Marchants();
        Task<(bool successful, MarchantDto marchants, bool fail)> MarchantById(string id);
    }
}
