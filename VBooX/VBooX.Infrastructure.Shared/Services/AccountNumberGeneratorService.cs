using System;
using System.Security.Cryptography;
using VBooX.Application.Interfaces;

namespace VBooX.Infrastructure.Shared.Services
{
    public class AccountNumberGeneratorService : IAccountNumberGeneratorService
    {
        public string GenerateAccountNumber() => GetDigits();
        private string GetDigits()
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D10}", random);
        }
    }
}
