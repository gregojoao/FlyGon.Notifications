# FlyGon.Notifications

[![NuGet](https://img.shields.io/nuget/v/FlyGon.Notifications.svg)](https://www.nuget.org/packages/FlyGon.Notifications/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A lightweight and powerful .NET library for implementing Domain Notification and Validation design patterns in your applications.

## Features

- ✅ **Domain Notification Pattern**: Collect and manage validation errors without throwing exceptions
- ✅ **Fluent Validation API**: Chain validation rules with an intuitive, readable syntax
- ✅ **Comprehensive Validators**: Built-in validators for common scenarios
- ✅ **.NET 10 Support**: Updated to the latest .NET version
- ✅ **Zero Dependencies**: No external dependencies required
- ✅ **High Performance**: Minimal overhead and optimized for speed
- ✅ **Well Tested**: 249+ unit tests with high code coverage

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package FlyGon.Notifications
```

Or via Package Manager Console:

```powershell
Install-Package FlyGon.Notifications
```

## Quick Start

### Basic Usage

```csharp
using FlyGon.Notifications;
using FlyGon.Notifications.Validations;

public class Customer : Notifiable
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public void Validate()
    {
        new Contract()
            .IsNotNullOrEmpty(Name, nameof(Name), "Name is required")
            .IsEmail(Email, nameof(Email), "Invalid email address")
            .IsGreaterThan(Age, 18, nameof(Age), "Must be 18 or older")
            .Validate(this);
    }
}

// Usage
var customer = new Customer 
{ 
    Name = "John Doe",
    Email = "invalid-email",
    Age = 16
};

customer.Validate();

if (customer.IsInvalid)
{
    foreach (var notification in customer.Notifications)
    {
        Console.WriteLine($"{notification.Property}: {notification.Message}");
    }
}
```

## Available Validators

### String Validations
- `IsNotNull` / `IsNotNullOrEmpty` / `IsNotNullOrWhiteSpace`
- `HasMinLength` / `HasMaxLength` / `HasLength`
- `Contains` / `AreEquals` / `AreNotEquals`
- `IsEmail` / `IsUrl`
- `Matches` (Regex)

### Numeric Validations (Int, Decimal, Double)
- `IsGreaterThan` / `IsGreaterOrEqualsThan`
- `IsLowerThan` / `IsLowerOrEqualsThan`
- `IsBetween`
- `IsPositive` / `IsNegative`

### DateTime Validations
- `IsGreaterThan` / `IsGreaterOrEqualsThan`
- `IsLowerThan` / `IsLowerOrEqualsThan`
- `IsBetween`

### Boolean Validations
- `IsTrue` / `IsFalse`

### Object Validations
- `IsNull` / `IsNotNull`
- `AreEquals` / `AreNotEquals`

### GUID Validations
- `IsEmpty` / `IsNotEmpty`
- `AreEquals` / `AreNotEquals`

### Brazilian Document Validations
- `IsCpf` / `IsCnpj` / `IsCpfOrCnpj`
- `IsCep` (Postal Code)
- `IsCnh` (Driver's License)
- `IsVoterDocument` (Voter Registration)
- `IsCarLicensePlate` (Vehicle License Plate)

### Phone Validations
- `IsPhoneNumber` (with country-specific validation)
- Supports: Brazil, USA, Portugal, and more

### Credit Card Validations
- `IsCreditCard` (Luhn algorithm validation)

## Advanced Usage

### Custom Notifications

```csharp
public class Order : Notifiable
{
    public void ProcessOrder()
    {
        if (Items.Count == 0)
        {
            AddNotification("Items", "Order must have at least one item");
        }
        
        if (TotalAmount <= 0)
        {
            AddNotification("TotalAmount", "Total amount must be greater than zero");
        }
    }
}
```

### Combining Multiple Validations

```csharp
public class Product : Notifiable
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public void Validate()
    {
        new Contract()
            .IsNotNullOrEmpty(Name, nameof(Name), "Product name is required")
            .HasMinLength(Name, 3, nameof(Name), "Name must have at least 3 characters")
            .HasMaxLength(Name, 100, nameof(Name), "Name cannot exceed 100 characters")
            .IsGreaterThan(Price, 0, nameof(Price), "Price must be greater than zero")
            .HasMaxLength(Description, 500, nameof(Description), "Description cannot exceed 500 characters")
            .Validate(this);
    }
}
```

### Clearing Notifications

```csharp
var customer = new Customer();
customer.Validate();

// Clear all notifications
customer.Clear();

// Check if valid
if (customer.IsValid)
{
    // Proceed with business logic
}
```

## Requirements

- .NET 10.0 or higher

## Migration from Previous Versions

If you're upgrading from version 1.x to 2.0:

- **Target Framework**: Updated from .NET Standard 2.1 to .NET 10.0
- **API Compatibility**: All public APIs remain backward compatible
- **Dependencies**: All NuGet packages updated to latest stable versions

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Author

**João Greco**  
Company: Greco Labs

## Repository

[https://github.com/grecojoao/FlyGon.Notifications](https://github.com/grecojoao/FlyGon.Notifications)

## Changelog

### Version 2.0.0
- ✨ Updated to .NET 10.0
- ⬆️ Updated all dependencies to latest versions
- ✅ All 249 unit tests passing
- 📝 Improved documentation
- 🏢 Company name updated to Greco Labs

### Version 1.1.2
- 📝 Added documentation
- 🐛 Bug fixes and improvements

## Support

If you encounter any issues or have questions, please [open an issue](https://github.com/grecojoao/FlyGon.Notifications/issues) on GitHub.
