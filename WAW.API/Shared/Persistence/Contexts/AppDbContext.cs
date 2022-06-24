using Microsoft.EntityFrameworkCore;
using WAW.API.Auth.Domain.Models;
using WAW.API.Employers.Domain.Models;
using WAW.API.Job.Domain.Models;
using WAW.API.Chat.Domain.Models;
using WAW.API.Shared.Extensions;

namespace WAW.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext {
  private DbSet<Offer>? offers;
  private DbSet<User>? users;
  private DbSet<Company>? companies;
  private DbSet<ChatRoom> chatRooms;
  private DbSet<Message> messages;

  public DbSet<Offer> Offers {
    get => GetContext(offers);
    set => offers = value;
  }

  public DbSet<User> Users {
    get => GetContext(users);
    set => users = value;
  }

  public DbSet<Company> Companies {
    get => GetContext(companies);
    set => companies = value;
  }

  public DbSet<ChatRoom> ChatRooms {
    get => GetContext(chatRooms);
    set => chatRooms = value;
  }

  public DbSet<Message> Messages {
    get => GetContext(messages);
    set => messages = value;
  }

  public AppDbContext(DbContextOptions options) : base(options) {}

  protected override void OnModelCreating(ModelBuilder builder) {
    base.OnModelCreating(builder);

    var chatRoomEntity = builder.Entity<ChatRoom>();
    chatRoomEntity.ToTable("ChatRoom");
    chatRoomEntity.HasKey(p => p.Id);
    chatRoomEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    chatRoomEntity.Property(p => p.Date).IsRequired();

    var messageEntity = builder.Entity<Message>();
    messageEntity.ToTable("Message");
    messageEntity.HasKey(p => p.Id);
    messageEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

    var offerEntity = builder.Entity<Offer>();
    offerEntity.ToTable("Offers");
    offerEntity.HasKey(p => p.Id);
    offerEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    offerEntity.Property(p => p.Title).IsRequired().HasMaxLength(256);
    offerEntity.Property(p => p.Image).HasMaxLength(2048);
    offerEntity.Property(p => p.Description).IsRequired();
    offerEntity.Property(p => p.Status).IsRequired();

    var userEntity = builder.Entity<User>();
    userEntity.ToTable("Users");
    userEntity.HasKey(p => p.Id);
    userEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    userEntity.Property(p => p.FullName).IsRequired().HasMaxLength(256);
    userEntity.Property(p => p.PreferredName).IsRequired().HasMaxLength(256);
    userEntity.Property(p => p.Email).IsRequired().HasMaxLength(256);
    userEntity.Property(p => p.Birthdate).IsRequired();
    userEntity.HasMany(p => p.Messages)
      .WithOne(p => p.User)
      .HasForeignKey(p => p.UserId);

    var companyEntity = builder.Entity<Company>();
    companyEntity.ToTable("Companies");
    companyEntity.HasKey(p => p.Id);
    companyEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    companyEntity.Property(p => p.Name).IsRequired().HasMaxLength(100);
    companyEntity.Property(p => p.Address).HasMaxLength(256);
    companyEntity.Property(p => p.Email).IsRequired().HasMaxLength(256);

    builder.UseSnakeCase();
  }

  private static T GetContext<T>(T? ctx) {
    if (ctx == null) throw new NullReferenceException();
    return ctx;
  }
}
