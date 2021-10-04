using System.Threading.Tasks;
using VBooX.Domain.Entities;

namespace VBooX.Application.Interfaces.Repositories
{
    public interface IVisitorBookRepositoryAsync : IGenericRepositoryAsync<VisitorBook>
    {
        Task<string> EncryptTagNo(string tagNo);

        void SendQRToVisitor(string filePath, VisitorBook visitorBook);

        void SendTagAsSMS(string tagNumber, VisitorBook visitorBook);
    }
}
