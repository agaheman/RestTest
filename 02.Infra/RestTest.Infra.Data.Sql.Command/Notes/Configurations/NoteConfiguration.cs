using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestTest.Core.Domain.Notes.Entities;

namespace RestTest.Infra.Data.Sql.Command.Notes.Configurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.Name).IsRequired(required: false);
        builder.Property(c => c.Published).IsRequired().HasDefaultValue(false);
        builder.Property(c => c.Content).IsRequired().HasMaxLength(250);
    }
}