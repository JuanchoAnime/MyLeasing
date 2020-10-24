namespace MyLeasing.Api.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore.Internal;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDatabase
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDatabase(DataContext dataContext, IUserHelper userHelper)
        {
            this._dataContext = dataContext;
            this._userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            await CheckPropertyTypesAsync();
            var manager = await CheckUserAsync("1010", "Juan", "Sierra", "judas3991@gmail.com", "3526789358", "Calle luna", "Manager");
            var owner = await CheckUserAsync("1010", "Juan", "Sierra", "js8332961@gmail.com", "3526789358", "Calle luna", "Owner");
            var lessee = await CheckUserAsync("1010", "Juan", "Sierra", "eliotandelon@gmail.com", "3526789358", "Calle luna", "Lessee");
            await CheckOwnerAsync(owner);
            await CheckLesseesAsync(lessee);
            await CheckManageAsync(manager);
            await CheckPropertiesAsync();
            await CheckContractsAsync();
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Manager");
            await _userHelper.CheckRoleAsync("Owner");
            await _userHelper.CheckRoleAsync("Lessee");
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

        private async Task<UserDto> CheckUserAsync(string document, string name, string lastName,
            string email, string cellPhone, string address, string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserDto
                {
                    Document = document,
                    FirstName = name,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = cellPhone,
                    Address = address,
                    UserName = email
                };
                await _userHelper.AddUserAsync(user, "12345678");
                await _userHelper.AddUserToRoleAsync(user, role);
            }
            return user;
        }

        private async Task CheckManageAsync(UserDto manager)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new ManagerDto { User = manager });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckLesseesAsync(UserDto lessee)
        {
            if (!_dataContext.Lessees.Any())
            {
                _dataContext.Lessees.Add(new LesseeDto { User = lessee });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckOwnerAsync(UserDto owner)
        {
            if (!_dataContext.Owners.Any())
            {
                _dataContext.Owners.Add(new OwnerDto { User = owner });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckContractsAsync() 
        {
            if (!_dataContext.Contracts.Any()) 
            {
                var owner = _dataContext.Owners.FirstOrDefault();
                var lessee = _dataContext.Lessees.FirstOrDefault();
                var property = _dataContext.Properties.FirstOrDefault();
                _dataContext.Contracts.Add(new ContractDto
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Today.AddYears(1),
                    IsActive = true,
                    Lessee = lessee,
                    Owner = owner,
                    Price = property.Price,
                    Property = property,
                    Remarks = "Lorem ipsum dolor sit amet, consectetur adipiscing"
                });
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
