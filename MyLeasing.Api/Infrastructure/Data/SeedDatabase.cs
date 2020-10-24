namespace MyLeasing.Api.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore.Internal;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDatabase
    {
        private readonly DataContext _dataContext;

        public SeedDatabase(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckPropertyTypesAsync();
            await CheckOwnerAsync();
            await CheckLesseesAsync();
            await CheckPropertiesAsync();
        }

        private async Task CheckPropertiesAsync()
        {
            if (!_dataContext.Properties.Any())
            {
                var owner = _dataContext.Owners.FirstOrDefault();
                var propertype = _dataContext.PropertyTypes.FirstOrDefault();
                AddProperty("Carrera #43 calle 73a 83", "Pobldo", owner, propertype, 80000000M, 2, 72, 4);
                AddProperty("Carrera #12 Sur calle 3a 43", "Envigado", owner, propertype, 95000000M, 3, 81, 3);
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddProperty(string addres, string neighborhood, OwnerDto owner,
            PropertyTypeDto propertype, decimal price, int rooms, int square, int stratum)
        {
            _dataContext.Properties.Add(new PropertyDto
            {
                Address = addres,
                Neighborhood = neighborhood,
                Owner = owner,
                HasParkingLot = false,
                Price = price,
                IsAvailable = true,
                Rooms = rooms,
                SquareMeters = square,
                Stratum = stratum,
                PropertyType = propertype,
                Remarks = ""
            });
        }

        private async Task CheckLesseesAsync()
        {
            if (!_dataContext.Lessees.Any())
            {
                AddLessee("456789876", "Ramon", "Gamboa", "65434567", "3167892876", "Calle luna");
                AddLessee("987656745", "Julian", "Martinez", "64567890", "3145678909", "Calle sol");
                AddLessee("456789876", "Carmenza", "Ruis", "67876543", "3123456789", "Calle #56");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddLessee(string document, string name, string lastName, 
            string fixedPhone, string cellPhone, string address)
        {
            _dataContext.Lessees.Add(new LesseeDto
            {
                Address = address,
                CellPhone = cellPhone,
                Document = document,
                FirstName = name,
                LastName = lastName,
                FixedPhone = fixedPhone
            });
        }

        private async Task CheckOwnerAsync()
        {
            if (!_dataContext.Owners.Any())
            {
                AddOwner("45678678", "Juan", "Zuluaga", "45676543", "3105678987", "Calle luna");
                AddOwner("56789098", "Jose", "Cardona", "45678876", "3198765498", "Calle sol");
                AddOwner("98764567", "Maria", "lópez", "78987659", "3134567872", "Calle #56");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddOwner(string document, string name, string lastName, 
            string fixedPhone, string cellPhone, string address)
        {
            _dataContext.Owners.Add(new OwnerDto
            {
                Address = address,
                CellPhone = cellPhone,
                Document = document,
                FirstName = name,
                LastName = lastName,
                FixedPhone = fixedPhone
            });
        }

        private async Task CheckPropertyTypesAsync()
        {
            if (!_dataContext.PropertyTypes.Any())
            {
                _dataContext.PropertyTypes.Add(new PropertyTypeDto { Name = "Apartamento" });
                _dataContext.PropertyTypes.Add(new PropertyTypeDto { Name = "Casa" });
                _dataContext.PropertyTypes.Add(new PropertyTypeDto { Name = "Negocio" });
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
