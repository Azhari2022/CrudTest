namespace CrudTest.Infra.Data.Ef.Configurations;
internal class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer", "dbo");


        builder.HasKey(o => o.Id);
        builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

        builder.Property(t => t.Firstname)
                .IsRequired()
                .HasColumnName("Firstname")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256)
                .HasConversion(
                    convertToProviderExpression: value => value!.Value,
                    convertFromProviderExpression: value => NameValueObject.From(value));

        builder.Property(t => t.Lastname)
            .IsRequired()
            .HasColumnName("Lastname")
            .HasColumnType("nvarchar(256)")
            .HasMaxLength(256)
            .HasConversion(
                    convertToProviderExpression: value => value!.Value,
                    convertFromProviderExpression: value => NameValueObject.From(value));

        builder.Property(t => t.DateOfBirth)
            .IsRequired()
            .HasColumnName("DateOfBirth")
            .HasColumnType("date")
            .HasConversion(
                    convertToProviderExpression: value => DateTime.Parse(value!.Value ?? string.Empty),
                    convertFromProviderExpression: value => DateOfBirthValueObject.From(DateOnly.FromDateTime(value).ToString()));

        builder.Property(t => t.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .HasConversion(
                    convertToProviderExpression: value => value!.Value,
                    convertFromProviderExpression: value => EmailValueObject.From(value));

        builder.Property(t => t.PhoneNumber)
            .IsRequired()
            .HasColumnName("PhoneNumber")
            .HasColumnType("numeric(18,0)")
            .HasConversion(
                    convertToProviderExpression: value => value!.Value,
                    convertFromProviderExpression: value => MobileValueObject.From(value)
                    );

       
        builder.HasIndex(t => t.Email)
            .IsUnique();
        builder.HasIndex(t => new { t.Firstname, t.Lastname, t.DateOfBirth })
            .IsUnique();

       // builder.Ignore(b => b.DomainEvents);
    }
}

