using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HanGang.MaterialSystem.Migrations
{
    public partial class 所有更改 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpAuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ApplicationName = table.Column<string>(maxLength: 96, nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    TenantName = table.Column<string>(nullable: true),
                    ImpersonatorUserId = table.Column<Guid>(nullable: true),
                    ImpersonatorTenantId = table.Column<Guid>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    ClientId = table.Column<string>(maxLength: 64, nullable: true),
                    CorrelationId = table.Column<string>(maxLength: 64, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    HttpMethod = table.Column<string>(maxLength: 16, nullable: true),
                    Url = table.Column<string>(maxLength: 256, nullable: true),
                    Exceptions = table.Column<string>(maxLength: 4000, nullable: true),
                    Comments = table.Column<string>(maxLength: 256, nullable: true),
                    HttpStatusCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpBackgroundJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    JobName = table.Column<string>(maxLength: 128, nullable: false),
                    JobArgs = table.Column<string>(maxLength: 1048576, nullable: false),
                    TryCount = table.Column<short>(nullable: false, defaultValue: (short)0),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    NextTryTime = table.Column<DateTime>(nullable: false),
                    LastTryTime = table.Column<DateTime>(nullable: true),
                    IsAbandoned = table.Column<bool>(nullable: false, defaultValue: false),
                    Priority = table.Column<byte>(nullable: false, defaultValue: (byte)15)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpBackgroundJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpClaimTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Required = table.Column<bool>(nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    Regex = table.Column<string>(maxLength: 512, nullable: true),
                    RegexDescription = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    ValueType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpClaimTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpFeatureValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderName = table.Column<string>(maxLength: 64, nullable: true),
                    ProviderKey = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatureValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpPermissionGrants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderName = table.Column<string>(maxLength: 64, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissionGrants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 256, nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2048, nullable: false),
                    ProviderName = table.Column<string>(maxLength: 64, nullable: true),
                    ProviderKey = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpTenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Surname = table.Column<string>(maxLength: 64, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false, defaultValue: false),
                    PasswordHash = table.Column<string>(maxLength: 256, nullable: true),
                    SecurityStamp = table.Column<string>(maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 16, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false, defaultValue: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false, defaultValue: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false, defaultValue: false),
                    AccessFailedCount = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerApiResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Properties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>(maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(maxLength: 2000, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    ProtocolType = table.Column<string>(maxLength: 200, nullable: false),
                    RequireClientSecret = table.Column<bool>(nullable: false),
                    RequireConsent = table.Column<bool>(nullable: false),
                    AllowRememberConsent = table.Column<bool>(nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(nullable: false),
                    RequirePkce = table.Column<bool>(nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(nullable: false),
                    FrontChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    BackChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    AllowOfflineAccess = table.Column<bool>(nullable: false),
                    IdentityTokenLifetime = table.Column<int>(nullable: false),
                    AccessTokenLifetime = table.Column<int>(nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>(nullable: false),
                    ConsentLifetime = table.Column<int>(nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(nullable: false),
                    RefreshTokenUsage = table.Column<int>(nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(nullable: false),
                    RefreshTokenExpiration = table.Column<int>(nullable: false),
                    AccessTokenType = table.Column<int>(nullable: false),
                    EnableLocalLogin = table.Column<bool>(nullable: false),
                    IncludeJwtId = table.Column<bool>(nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>(nullable: false),
                    ClientClaimsPrefix = table.Column<string>(maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(maxLength: 200, nullable: true),
                    UserSsoLifetime = table.Column<int>(nullable: true),
                    UserCodeType = table.Column<string>(maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerIdentityResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    Properties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerIdentityResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerPersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerPersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Material_DemoProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    OldName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_DemoProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material_Manufactorys",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    TelePhone = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_Manufactorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material_Trials",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TrialType = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_Trials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_Trials_Material_Trials_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Material_Trials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_TypicalParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    AppliedVehicleType = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_TypicalParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpAuditLogActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    AuditLogId = table.Column<Guid>(nullable: false),
                    ServiceName = table.Column<string>(maxLength: 256, nullable: true),
                    MethodName = table.Column<string>(maxLength: 128, nullable: true),
                    Parameters = table.Column<string>(maxLength: 2000, nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpAuditLogActions_AbpAuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "AbpAuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuditLogId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    EntityTenantId = table.Column<Guid>(nullable: true),
                    EntityId = table.Column<string>(maxLength: 128, nullable: false),
                    EntityTypeFullName = table.Column<string>(maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityChanges_AbpAuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "AbpAuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpRoleClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: false),
                    ClaimValue = table.Column<string>(maxLength: 1024, nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpRoleClaims_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpTenantConnectionStrings",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenantConnectionStrings", x => new { x.TenantId, x.Name });
                    table.ForeignKey(
                        name: "FK_AbpTenantConnectionStrings_AbpTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: false),
                    ClaimValue = table.Column<string>(maxLength: 1024, nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserClaims_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 64, nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ProviderKey = table.Column<string>(maxLength: 196, nullable: false),
                    ProviderDisplayName = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserLogins", x => new { x.UserId, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_AbpUserLogins_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AbpUserRoles_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpUserRoles_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AbpUserTokens_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerApiClaims",
                columns: table => new
                {
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    ApiResourceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiClaims", x => new { x.ApiResourceId, x.Type });
                    table.ForeignKey(
                        name: "FK_IdentityServerApiClaims_IdentityServerApiResources_ApiResou~",
                        column: x => x.ApiResourceId,
                        principalTable: "IdentityServerApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerApiScopes",
                columns: table => new
                {
                    ApiResourceId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiScopes", x => new { x.ApiResourceId, x.Name });
                    table.ForeignKey(
                        name: "FK_IdentityServerApiScopes_IdentityServerApiResources_ApiResou~",
                        column: x => x.ApiResourceId,
                        principalTable: "IdentityServerApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerApiSecrets",
                columns: table => new
                {
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    ApiResourceId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiSecrets", x => new { x.ApiResourceId, x.Type, x.Value });
                    table.ForeignKey(
                        name: "FK_IdentityServerApiSecrets_IdentityServerApiResources_ApiReso~",
                        column: x => x.ApiResourceId,
                        principalTable: "IdentityServerApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientClaims",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientClaims", x => new { x.ClientId, x.Type, x.Value });
                    table.ForeignKey(
                        name: "FK_IdentityServerClientClaims_IdentityServerClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "IdentityServerClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientCorsOrigins",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Origin = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientCorsOrigins", x => new { x.ClientId, x.Origin });
                    table.ForeignKey(
                        name: "FK_IdentityServerClientCorsOrigins_IdentityServerClients_Clien~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServerClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientGrantTypes",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    GrantType = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientGrantTypes", x => new { x.ClientId, x.GrantType });
                    table.ForeignKey(
                        name: "FK_IdentityServerClientGrantTypes_IdentityServerClients_Client~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServerClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientIdPRestrictions",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Provider = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientIdPRestrictions", x => new { x.ClientId, x.Provider });
                    table.ForeignKey(
                        name: "FK_IdentityServerClientIdPRestrictions_IdentityServerClients_C~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServerClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientPostLogoutRedirectUris",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    PostLogoutRedirectUri = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientPostLogoutRedirectUris", x => new { x.ClientId, x.PostLogoutRedirectUri });
                    table.ForeignKey(
                        name: "FK_IdentityServerClientPostLogoutRedirectUris_IdentityServerCl~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServerClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientProperties",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientProperties", x => new { x.ClientId, x.Key });
                    table.ForeignKey(
                        name: "FK_IdentityServerClientProperties_IdentityServerClients_Client~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServerClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientRedirectUris",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    RedirectUri = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientRedirectUris", x => new { x.ClientId, x.RedirectUri });
                    table.ForeignKey(
                        name: "FK_IdentityServerClientRedirectUris_IdentityServerClients_Clie~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServerClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientScopes",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Scope = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientScopes", x => new { x.ClientId, x.Scope });
                    table.ForeignKey(
                        name: "FK_IdentityServerClientScopes_IdentityServerClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "IdentityServerClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientSecrets",
                columns: table => new
                {
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientSecrets", x => new { x.ClientId, x.Type, x.Value });
                    table.ForeignKey(
                        name: "FK_IdentityServerClientSecrets_IdentityServerClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "IdentityServerClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerIdentityClaims",
                columns: table => new
                {
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    IdentityResourceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerIdentityClaims", x => new { x.IdentityResourceId, x.Type });
                    table.ForeignKey(
                        name: "FK_IdentityServerIdentityClaims_IdentityServerIdentityResource~",
                        column: x => x.IdentityResourceId,
                        principalTable: "IdentityServerIdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material_DemoUnitProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    DemoProjectId = table.Column<Guid>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_DemoUnitProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_DemoUnitProjects_Material_DemoProjects_DemoProject~",
                        column: x => x.DemoProjectId,
                        principalTable: "Material_DemoProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    MaxModel = table.Column<decimal>(nullable: true),
                    MinModel = table.Column<decimal>(nullable: true),
                    Strength = table.Column<decimal>(nullable: true),
                    MaterialType = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    AppliedVehicleType = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    TypicalPartId = table.Column<Guid>(nullable: true),
                    ManufactoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_Materials_Material_Manufactorys_ManufactoryId",
                        column: x => x.ManufactoryId,
                        principalTable: "Material_Manufactorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Material_Materials_Material_TypicalParts_TypicalPartId",
                        column: x => x.TypicalPartId,
                        principalTable: "Material_TypicalParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    EntityChangeId = table.Column<Guid>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 128, nullable: false),
                    PropertyTypeFullName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
                        column: x => x.EntityChangeId,
                        principalTable: "AbpEntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerApiScopeClaims",
                columns: table => new
                {
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    ApiResourceId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiScopeClaims", x => new { x.ApiResourceId, x.Name, x.Type });
                    table.ForeignKey(
                        name: "FK_IdentityServerApiScopeClaims_IdentityServerApiScopes_ApiRes~",
                        columns: x => new { x.ApiResourceId, x.Name },
                        principalTable: "IdentityServerApiScopes",
                        principalColumns: new[] { "ApiResourceId", "Name" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material_MaterialTrials",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    MaterialId = table.Column<Guid>(nullable: true),
                    TrialId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_MaterialTrials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_MaterialTrials_Material_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material_Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Material_MaterialTrials_Material_Trials_TrialId",
                        column: x => x.TrialId,
                        principalTable: "Material_Trials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_MaterialTrialDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_MaterialTrialDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_MaterialTrialDatas_Material_MaterialTrials_Materia~",
                        column: x => x.MaterialTrialId,
                        principalTable: "Material_MaterialTrials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_BakeHardeningDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    BH = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_BakeHardeningDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_BakeHardeningDataDetails_Material_MaterialTrialDat~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_BendingDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    BendingStrength = table.Column<decimal>(nullable: true),
                    NonProportionalBendingStrenth = table.Column<decimal>(nullable: true),
                    BendingOfElasticity = table.Column<decimal>(nullable: true),
                    Span = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_BendingDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_BendingDataDetails_Material_MaterialTrialDatas_Mat~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_CementingDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    CementingWidth = table.Column<decimal>(nullable: true),
                    MPA = table.Column<decimal>(nullable: true),
                    FailureMode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_CementingDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_CementingDataDetails_Material_MaterialTrialDatas_M~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_ChemicalElementDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    Requirement = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Element = table.Column<string>(nullable: true),
                    ContentRatio = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_ChemicalElementDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_ChemicalElementDataDetails_Material_MaterialTrialD~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_CompressDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    CompressiveStrength = table.Column<decimal>(nullable: true),
                    NonProportionalCompressStrenth = table.Column<decimal>(nullable: true),
                    CompressOfElasticity = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_CompressDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_CompressDataDetails_Material_MaterialTrialDatas_Ma~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_DentResistanceDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    OriginalRigidity = table.Column<decimal>(nullable: true),
                    VisibleDentLoad = table.Column<decimal>(nullable: true),
                    PrimaryLoadingCurveString = table.Column<string>(nullable: true),
                    PrimaryLoadingCurveKey = table.Column<string>(nullable: true),
                    CyclicLoadingCurveString = table.Column<string>(nullable: true),
                    CyclicLoadingCurveKey = table.Column<string>(nullable: true),
                    DentDpthLoadCurveString = table.Column<string>(nullable: true),
                    DentDpthLoadCurveKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_DentResistanceDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_DentResistanceDataDetails_Material_MaterialTrialDa~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_FlangingClaspDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    FlangingLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_FlangingClaspDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_FlangingClaspDataDetails_Material_MaterialTrialDat~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_FLDDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    LimitStrain = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_FLDDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_FLDDataDetails_Material_MaterialTrialDatas_Materia~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_HighCycleFatigueDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    UseExtensometer = table.Column<bool>(nullable: true),
                    ExtensometerGaugeDistance = table.Column<decimal>(nullable: true),
                    SurfaceQuality = table.Column<string>(nullable: true),
                    CyclicStressRatio = table.Column<string>(nullable: true),
                    Formula = table.Column<string>(nullable: true),
                    SNAParameter = table.Column<decimal>(nullable: true),
                    SNBParameter = table.Column<decimal>(nullable: true),
                    SNRelatedParameter = table.Column<decimal>(nullable: true),
                    FatigueLimitStrength = table.Column<decimal>(nullable: true),
                    StandardDeviation = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_HighCycleFatigueDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_HighCycleFatigueDataDetails_Material_MaterialTrial~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_HighSpeedStrechDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    YoungModulu = table.Column<decimal>(nullable: true),
                    PoissonRatio = table.Column<decimal>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    TestTarget = table.Column<decimal>(nullable: true),
                    YieldStrength = table.Column<decimal>(nullable: true),
                    TensileStrength = table.Column<decimal>(nullable: true),
                    Elongation = table.Column<decimal>(nullable: true),
                    StretchingSpeed = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_HighSpeedStrechDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_HighSpeedStrechDataDetails_Material_MaterialTrialD~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_HydrogenInducedDelayedFractureDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    TestName = table.Column<string>(nullable: true),
                    Device = table.Column<string>(nullable: true),
                    LiquorType = table.Column<string>(nullable: true),
                    TestTime = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_HydrogenInducedDelayedFractureDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_HydrogenInducedDelayedFractureDataDetails_Material~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_LowCycleFatigueDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    UseExtensometer = table.Column<bool>(nullable: true),
                    ExtensometerGaugeDistance = table.Column<decimal>(nullable: true),
                    SurfaceQuality = table.Column<string>(nullable: true),
                    CyclicStrainRatio = table.Column<string>(nullable: true),
                    CyclicStrengthParameter = table.Column<decimal>(nullable: true),
                    CyclicStrainHardening = table.Column<decimal>(nullable: true),
                    RelatedSressParameter = table.Column<decimal>(nullable: true),
                    FatigueStrengthParameter = table.Column<decimal>(nullable: true),
                    FatigueStrength = table.Column<decimal>(nullable: true),
                    RelatedLifeFatigueParameter = table.Column<decimal>(nullable: true),
                    FatigueStrechParameter = table.Column<decimal>(nullable: true),
                    FatigueStrech = table.Column<decimal>(nullable: true),
                    RelatedLifeStrechParameter = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_LowCycleFatigueDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_LowCycleFatigueDataDetails_Material_MaterialTrialD~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_MetallographicDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    Structure = table.Column<string>(nullable: true),
                    NonMetallicInclusionLevel = table.Column<string>(nullable: true),
                    GrainSize = table.Column<decimal>(nullable: true),
                    DepthDecarburization = table.Column<decimal>(nullable: true),
                    StructureString = table.Column<string>(nullable: true),
                    StructureKey = table.Column<string>(nullable: true),
                    StructurBytes = table.Column<byte[]>(nullable: true),
                    NonMetallicInclusionLevelString = table.Column<string>(nullable: true),
                    NonMetallicInclusionLevelKey = table.Column<string>(nullable: true),
                    NonMetallicInclusionLevelBytes = table.Column<byte[]>(nullable: true),
                    GrainSizeString = table.Column<string>(nullable: true),
                    GrainSizeKey = table.Column<string>(nullable: true),
                    GrainSizeBytes = table.Column<byte[]>(nullable: true),
                    DepthDecarburizationString = table.Column<string>(nullable: true),
                    DepthDecarburizationKey = table.Column<string>(nullable: true),
                    DepthDecarburizationBytes = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_MetallographicDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_MetallographicDataDetails_Material_MaterialTrialDa~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PaintingDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PaintingDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PaintingDataDetails_Material_MaterialTrialDatas_Ma~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PhysicalPerformanceDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    HV = table.Column<decimal>(nullable: true),
                    HBW = table.Column<decimal>(nullable: true),
                    HRC = table.Column<decimal>(nullable: true),
                    Density = table.Column<decimal>(nullable: true),
                    Resistivity = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PhysicalPerformanceDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PhysicalPerformanceDataDetails_Material_MaterialTr~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_ProhibitedSubstanceDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Element = table.Column<string>(nullable: true),
                    ContentRatio = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_ProhibitedSubstanceDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_ProhibitedSubstanceDataDetails_Material_MaterialTr~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_ReboundDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    SampleSize = table.Column<string>(nullable: true),
                    TestType = table.Column<string>(nullable: true),
                    BendingAngleRange = table.Column<string>(nullable: true),
                    TestSpeed = table.Column<decimal>(nullable: true),
                    HoldStress = table.Column<decimal>(nullable: true),
                    HoldTimes = table.Column<int>(nullable: true),
                    PunchFilletRadiusRange = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_ReboundDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_ReboundDataDetails_Material_MaterialTrialDatas_Mat~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_SecondaryWorkingEmbrittlementDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_SecondaryWorkingEmbrittlementDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_SecondaryWorkingEmbrittlementDataDetails_Material_~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_StaticTensionDataDetailRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    Thickness = table.Column<string>(nullable: true),
                    NonProportionalExtendRatio = table.Column<string>(nullable: true),
                    YieldStrength = table.Column<string>(nullable: true),
                    TensileStrength = table.Column<string>(nullable: true),
                    StrainHardening = table.Column<string>(nullable: true),
                    Elongation = table.Column<string>(nullable: true),
                    PlasticStrainRatio = table.Column<string>(nullable: true),
                    ModulusOfElasticity = table.Column<string>(nullable: true),
                    PoissonRatio = table.Column<string>(nullable: true),
                    MaximumForce = table.Column<string>(nullable: true),
                    BHValue = table.Column<string>(nullable: true),
                    IndenterDiameter = table.Column<string>(nullable: true),
                    VImpactTemperature = table.Column<string>(nullable: true),
                    VImpactEnergy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_StaticTensionDataDetailRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_StaticTensionDataDetailRequirements_Material_Mater~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_StaticTensionDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    NonProportionalExtendRatio = table.Column<decimal>(nullable: true),
                    YieldStrength = table.Column<decimal>(nullable: true),
                    TensileStrength = table.Column<decimal>(nullable: true),
                    StrainHardening = table.Column<decimal>(nullable: true),
                    Elongation = table.Column<decimal>(nullable: true),
                    PlasticStrainRatio = table.Column<decimal>(nullable: true),
                    ModulusOfElasticity = table.Column<decimal>(nullable: true),
                    PoissonRatio = table.Column<decimal>(nullable: true),
                    MaximumForce = table.Column<decimal>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    BHValue = table.Column<decimal>(nullable: true),
                    IndenterDiameter = table.Column<decimal>(nullable: true),
                    VImpactTemperature = table.Column<decimal>(nullable: true),
                    VImpactEnergy = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_StaticTensionDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_StaticTensionDataDetails_Material_MaterialTrialDat~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_SurfacePropertyDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_SurfacePropertyDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_SurfacePropertyDataDetails_Material_MaterialTrialD~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_WeldingDataDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MaterialTrialDataId = table.Column<Guid>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    TestOrganization = table.Column<string>(nullable: true),
                    TestMethod = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Width = table.Column<decimal>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    GaugeDistance = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileString2 = table.Column<string>(nullable: true),
                    FileString3 = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileBytes = table.Column<byte[]>(nullable: true),
                    FormYieldStrength = table.Column<decimal>(nullable: true),
                    FormTensileStrength = table.Column<decimal>(nullable: true),
                    FormElongation = table.Column<decimal>(nullable: true),
                    FormModulusOfElasticity = table.Column<decimal>(nullable: true),
                    TestType = table.Column<string>(nullable: true),
                    WelderType = table.Column<string>(nullable: true),
                    WelderMode = table.Column<string>(nullable: true),
                    HeadDiameter = table.Column<decimal>(nullable: true),
                    ElectrodePressure = table.Column<decimal>(nullable: true),
                    PulseTimes = table.Column<int>(nullable: true),
                    PreloadingTimes = table.Column<int>(nullable: true),
                    BoostTimes = table.Column<int>(nullable: true),
                    MinimumWeldingTimes = table.Column<int>(nullable: true),
                    MiddleWeldingTimes = table.Column<int>(nullable: true),
                    MaxmumWeldingTimes = table.Column<int>(nullable: true),
                    HoldingWeldingTimes = table.Column<int>(nullable: true),
                    CriticalJointDiameter = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_WeldingDataDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_WeldingDataDetails_Material_MaterialTrialDatas_Mat~",
                        column: x => x.MaterialTrialDataId,
                        principalTable: "Material_MaterialTrialDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_BakeHardeningDataDetailItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    BakeHardeningDataDetailId = table.Column<Guid>(nullable: true),
                    TemperatureTimes = table.Column<string>(nullable: true),
                    Rt = table.Column<decimal>(nullable: true),
                    Rp = table.Column<decimal>(nullable: true),
                    Rm = table.Column<decimal>(nullable: true),
                    BH2 = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_BakeHardeningDataDetailItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_BakeHardeningDataDetailItems_Material_BakeHardenin~",
                        column: x => x.BakeHardeningDataDetailId,
                        principalTable: "Material_BakeHardeningDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_FLDDataDetailItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FLDDataDetailId = table.Column<Guid>(nullable: true),
                    SpecimenWidth = table.Column<decimal>(nullable: true),
                    MainStrain = table.Column<decimal>(nullable: true),
                    SecondaryStrain = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_FLDDataDetailItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_FLDDataDetailItems_Material_FLDDataDetails_FLDData~",
                        column: x => x.FLDDataDetailId,
                        principalTable: "Material_FLDDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_HighCycleFatigueDataDetailItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    HighCycleFatigueDataDetailId = table.Column<Guid>(nullable: true),
                    ItemSampleCode = table.Column<string>(nullable: true),
                    MaximumStress = table.Column<decimal>(nullable: true),
                    StressAmplitude = table.Column<decimal>(nullable: true),
                    TestFrequency = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_HighCycleFatigueDataDetailItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_HighCycleFatigueDataDetailItems_Material_HighCycle~",
                        column: x => x.HighCycleFatigueDataDetailId,
                        principalTable: "Material_HighCycleFatigueDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_HighSpeedStrechDataDetailStressStrainExtends",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    HighSpeedStrechDataDetailId = table.Column<Guid>(nullable: true),
                    RealPlasticStressExtend = table.Column<decimal>(nullable: true),
                    RealPlasticStrainExtend = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_HighSpeedStrechDataDetailStressStrainExtends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_HighSpeedStrechDataDetailStressStrainExtends_Mater~",
                        column: x => x.HighSpeedStrechDataDetailId,
                        principalTable: "Material_HighSpeedStrechDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_HighSpeedStrechDataDetailStressStrains",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    HighSpeedStrechDataDetailId = table.Column<Guid>(nullable: true),
                    EngineeringStress = table.Column<decimal>(nullable: true),
                    EngineeringStrain = table.Column<decimal>(nullable: true),
                    RealStress = table.Column<decimal>(nullable: true),
                    RealStrain = table.Column<decimal>(nullable: true),
                    RealPlasticStress = table.Column<decimal>(nullable: true),
                    RealPlasticStrain = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_HighSpeedStrechDataDetailStressStrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_HighSpeedStrechDataDetailStressStrains_Material_Hi~",
                        column: x => x.HighSpeedStrechDataDetailId,
                        principalTable: "Material_HighSpeedStrechDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_HydrogenInducedDelayedFractureDataDetailItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    HydrogenInducedDelayedFractureDataDetailId = table.Column<Guid>(nullable: true),
                    Span = table.Column<decimal>(nullable: true),
                    Strain = table.Column<decimal>(nullable: true),
                    Stress = table.Column<decimal>(nullable: true),
                    Hour = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_HydrogenInducedDelayedFractureDataDetailItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_HydrogenInducedDelayedFractureDataDetailItems_Mate~",
                        column: x => x.HydrogenInducedDelayedFractureDataDetailId,
                        principalTable: "Material_HydrogenInducedDelayedFractureDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_LowCycleFatigueDataDetailItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    LowCycleFatigueDataDetailId = table.Column<Guid>(nullable: true),
                    SampleCode = table.Column<string>(nullable: true),
                    TotalStrainAmplitude = table.Column<decimal>(nullable: true),
                    PlasticStrainAmplitude = table.Column<decimal>(nullable: true),
                    ElasticStrainAmplitude = table.Column<decimal>(nullable: true),
                    FailureCycleTimes = table.Column<int>(nullable: true),
                    CycleStressAmplitude = table.Column<decimal>(nullable: true),
                    TestFrequency = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_LowCycleFatigueDataDetailItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_LowCycleFatigueDataDetailItems_Material_LowCycleFa~",
                        column: x => x.LowCycleFatigueDataDetailId,
                        principalTable: "Material_LowCycleFatigueDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PaintingDataDetailAdhesionItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PaintingDataDetailId = table.Column<Guid>(nullable: true),
                    PointAdhesionOne = table.Column<decimal>(nullable: true),
                    PointAdhesionTwo = table.Column<decimal>(nullable: true),
                    PointAdhesionThree = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PaintingDataDetailAdhesionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PaintingDataDetailAdhesionItems_Material_PaintingD~",
                        column: x => x.PaintingDataDetailId,
                        principalTable: "Material_PaintingDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PaintingDataDetailDampHeatItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PaintingDataDetailId = table.Column<Guid>(nullable: true),
                    PointOne = table.Column<decimal>(nullable: true),
                    PointTwo = table.Column<decimal>(nullable: true),
                    PointThree = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PaintingDataDetailDampHeatItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PaintingDataDetailDampHeatItems_Material_PaintingD~",
                        column: x => x.PaintingDataDetailId,
                        principalTable: "Material_PaintingDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PaintingDataDetailElectrophoreticItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PaintingDataDetailId = table.Column<Guid>(nullable: true),
                    PointThickOne = table.Column<decimal>(nullable: true),
                    PointThickTwo = table.Column<decimal>(nullable: true),
                    PointThickThree = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PaintingDataDetailElectrophoreticItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PaintingDataDetailElectrophoreticItems_Material_Pa~",
                        column: x => x.PaintingDataDetailId,
                        principalTable: "Material_PaintingDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PaintingDataDetailHardnessItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PaintingDataDetailId = table.Column<Guid>(nullable: true),
                    PointHardness = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PaintingDataDetailHardnessItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PaintingDataDetailHardnessItems_Material_PaintingD~",
                        column: x => x.PaintingDataDetailId,
                        principalTable: "Material_PaintingDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PaintingDataDetailHitResistanceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PaintingDataDetailId = table.Column<Guid>(nullable: true),
                    PointStrength = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PaintingDataDetailHitResistanceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PaintingDataDetailHitResistanceItems_Material_Pain~",
                        column: x => x.PaintingDataDetailId,
                        principalTable: "Material_PaintingDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PaintingDataDetailMembraneWeightItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PaintingDataDetailId = table.Column<Guid>(nullable: true),
                    Area = table.Column<decimal>(nullable: true),
                    OriginalWeight = table.Column<decimal>(nullable: true),
                    AfterWeight = table.Column<decimal>(nullable: true),
                    MembraneWeight = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PaintingDataDetailMembraneWeightItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PaintingDataDetailMembraneWeightItems_Material_Pai~",
                        column: x => x.PaintingDataDetailId,
                        principalTable: "Material_PaintingDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PaintingDataDetailPhosphatingItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PaintingDataDetailId = table.Column<Guid>(nullable: true),
                    SizeText = table.Column<string>(nullable: true),
                    CoverRatio = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PaintingDataDetailPhosphatingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PaintingDataDetailPhosphatingItems_Material_Painti~",
                        column: x => x.PaintingDataDetailId,
                        principalTable: "Material_PaintingDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PaintingDataDetailPRatioItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PaintingDataDetailId = table.Column<Guid>(nullable: true),
                    Ip = table.Column<decimal>(nullable: true),
                    IH = table.Column<decimal>(nullable: true),
                    Ratio = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PaintingDataDetailPRatioItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PaintingDataDetailPRatioItems_Material_PaintingDat~",
                        column: x => x.PaintingDataDetailId,
                        principalTable: "Material_PaintingDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PaintingDataDetailRoughnessItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PaintingDataDetailId = table.Column<Guid>(nullable: true),
                    RaOne = table.Column<decimal>(nullable: true),
                    RaTwo = table.Column<decimal>(nullable: true),
                    RaThree = table.Column<decimal>(nullable: true),
                    RzOne = table.Column<decimal>(nullable: true),
                    RzTwo = table.Column<decimal>(nullable: true),
                    RzThree = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PaintingDataDetailRoughnessItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PaintingDataDetailRoughnessItems_Material_Painting~",
                        column: x => x.PaintingDataDetailId,
                        principalTable: "Material_PaintingDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PhysicalPerformanceDataDetailThermalConductivitys",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PhysicalPerformanceDataDetailId = table.Column<Guid>(nullable: true),
                    Temperature = table.Column<decimal>(nullable: true),
                    ThermalConductivity = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PhysicalPerformanceDataDetailThermalConductivitys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PhysicalPerformanceDataDetailThermalConductivitys_~",
                        column: x => x.PhysicalPerformanceDataDetailId,
                        principalTable: "Material_PhysicalPerformanceDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_PhysicalPerformanceDataDetailThermalExpansions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PhysicalPerformanceDataDetailId = table.Column<Guid>(nullable: true),
                    TemperatureRange = table.Column<string>(nullable: true),
                    ThermalExpansion = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_PhysicalPerformanceDataDetailThermalExpansions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_PhysicalPerformanceDataDetailThermalExpansions_Mat~",
                        column: x => x.PhysicalPerformanceDataDetailId,
                        principalTable: "Material_PhysicalPerformanceDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_ReboundDataDetailItem2s",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ReboundDataDetailId = table.Column<Guid>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    BendingAngle = table.Column<decimal>(nullable: true),
                    Rt1 = table.Column<string>(nullable: true),
                    Rt2 = table.Column<string>(nullable: true),
                    Rt3 = table.Column<string>(nullable: true),
                    Rt4 = table.Column<string>(nullable: true),
                    Rt5 = table.Column<string>(nullable: true),
                    Rt6 = table.Column<string>(nullable: true),
                    RtMin = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_ReboundDataDetailItem2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_ReboundDataDetailItem2s_Material_ReboundDataDetail~",
                        column: x => x.ReboundDataDetailId,
                        principalTable: "Material_ReboundDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_ReboundDataDetailItem3s",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ReboundDataDetailId = table.Column<Guid>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    Rt1 = table.Column<string>(nullable: true),
                    Rt2 = table.Column<string>(nullable: true),
                    Rt3 = table.Column<string>(nullable: true),
                    Rt4 = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_ReboundDataDetailItem3s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_ReboundDataDetailItem3s_Material_ReboundDataDetail~",
                        column: x => x.ReboundDataDetailId,
                        principalTable: "Material_ReboundDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_ReboundDataDetailItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ReboundDataDetailId = table.Column<Guid>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    Thickness = table.Column<decimal>(nullable: true),
                    PunchFilletRadius = table.Column<string>(nullable: true),
                    BendingAngle = table.Column<decimal>(nullable: true),
                    MeasuringAngle = table.Column<decimal>(nullable: true),
                    ReboundAngle = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_ReboundDataDetailItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_ReboundDataDetailItems_Material_ReboundDataDetails~",
                        column: x => x.ReboundDataDetailId,
                        principalTable: "Material_ReboundDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_SecondaryWorkingEmbrittlementDataDetailItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SecondaryWorkingEmbrittlementDataDetailId = table.Column<Guid>(nullable: true),
                    Temperature = table.Column<decimal>(nullable: true),
                    Swet = table.Column<decimal>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    ExpansionType = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_SecondaryWorkingEmbrittlementDataDetailItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_SecondaryWorkingEmbrittlementDataDetailItems_Mater~",
                        column: x => x.SecondaryWorkingEmbrittlementDataDetailId,
                        principalTable: "Material_SecondaryWorkingEmbrittlementDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_StaticTensionDataDetailStressStrains",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    StaticTensionDataDetailId = table.Column<Guid>(nullable: true),
                    Stress = table.Column<decimal>(nullable: true),
                    Strain = table.Column<decimal>(nullable: true),
                    RealStress = table.Column<decimal>(nullable: true),
                    RealStrain = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_StaticTensionDataDetailStressStrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_StaticTensionDataDetailStressStrains_Material_Stat~",
                        column: x => x.StaticTensionDataDetailId,
                        principalTable: "Material_StaticTensionDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_SurfacePropertyCoatingWeights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SurfacePropertyDataDetailId = table.Column<Guid>(nullable: true),
                    Area = table.Column<decimal>(nullable: true),
                    OriginalWeight = table.Column<decimal>(nullable: true),
                    AfterWeight = table.Column<decimal>(nullable: true),
                    MembraneWeight = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_SurfacePropertyCoatingWeights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_SurfacePropertyCoatingWeights_Material_SurfaceProp~",
                        column: x => x.SurfacePropertyDataDetailId,
                        principalTable: "Material_SurfacePropertyDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_SurfacePropertyRoughnesss",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SurfacePropertyDataDetailId = table.Column<Guid>(nullable: true),
                    RaOne = table.Column<decimal>(nullable: true),
                    RaTwo = table.Column<decimal>(nullable: true),
                    RPCOne = table.Column<decimal>(nullable: true),
                    RPCTwo = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_SurfacePropertyRoughnesss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_SurfacePropertyRoughnesss_Material_SurfaceProperty~",
                        column: x => x.SurfacePropertyDataDetailId,
                        principalTable: "Material_SurfacePropertyDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_WeldingDataDetailItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    WeldingDataDetailId = table.Column<Guid>(nullable: true),
                    WeldingCurrentInterval = table.Column<decimal>(nullable: true),
                    LeftBoundaryElectric = table.Column<decimal>(nullable: true),
                    RightBoundaryElectric = table.Column<decimal>(nullable: true),
                    WeldingTimes = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_WeldingDataDetailItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_WeldingDataDetailItems_Material_WeldingDataDetails~",
                        column: x => x.WeldingDataDetailId,
                        principalTable: "Material_WeldingDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogActions_AuditLogId",
                table: "AbpAuditLogActions",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogActions_TenantId_ServiceName_MethodName_Executio~",
                table: "AbpAuditLogActions",
                columns: new[] { "TenantId", "ServiceName", "MethodName", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_ExecutionTime",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_UserId_ExecutionTime",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "UserId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime",
                table: "AbpBackgroundJobs",
                columns: new[] { "IsAbandoned", "NextTryTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_AuditLogId",
                table: "AbpEntityChanges",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId",
                table: "AbpEntityChanges",
                columns: new[] { "TenantId", "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityPropertyChanges_EntityChangeId",
                table: "AbpEntityPropertyChanges",
                column: "EntityChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatureValues_Name_ProviderName_ProviderKey",
                table: "AbpFeatureValues",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissionGrants_Name_ProviderName_ProviderKey",
                table: "AbpPermissionGrants",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoleClaims_RoleId",
                table: "AbpRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_NormalizedName",
                table: "AbpRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_Name_ProviderName_ProviderKey",
                table: "AbpSettings",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_Name",
                table: "AbpTenants",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserClaims_UserId",
                table: "AbpUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_LoginProvider_ProviderKey",
                table: "AbpUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_RoleId_UserId",
                table: "AbpUserRoles",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_Email",
                table: "AbpUsers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_NormalizedEmail",
                table: "AbpUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_NormalizedUserName",
                table: "AbpUsers",
                column: "NormalizedUserName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_UserName",
                table: "AbpUsers",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServerClients_ClientId",
                table: "IdentityServerClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServerPersistedGrants_Expiration",
                table: "IdentityServerPersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServerPersistedGrants_SubjectId_ClientId_Type",
                table: "IdentityServerPersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Material_BakeHardeningDataDetailItems_BakeHardeningDataDeta~",
                table: "Material_BakeHardeningDataDetailItems",
                column: "BakeHardeningDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_BakeHardeningDataDetails_MaterialTrialDataId",
                table: "Material_BakeHardeningDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_BendingDataDetails_MaterialTrialDataId",
                table: "Material_BendingDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_CementingDataDetails_MaterialTrialDataId",
                table: "Material_CementingDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_ChemicalElementDataDetails_MaterialTrialDataId",
                table: "Material_ChemicalElementDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_CompressDataDetails_MaterialTrialDataId",
                table: "Material_CompressDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_DemoUnitProjects_DemoProjectId",
                table: "Material_DemoUnitProjects",
                column: "DemoProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_DentResistanceDataDetails_MaterialTrialDataId",
                table: "Material_DentResistanceDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_FlangingClaspDataDetails_MaterialTrialDataId",
                table: "Material_FlangingClaspDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_FLDDataDetailItems_FLDDataDetailId",
                table: "Material_FLDDataDetailItems",
                column: "FLDDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_FLDDataDetails_MaterialTrialDataId",
                table: "Material_FLDDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_HighCycleFatigueDataDetailItems_HighCycleFatigueDa~",
                table: "Material_HighCycleFatigueDataDetailItems",
                column: "HighCycleFatigueDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_HighCycleFatigueDataDetails_MaterialTrialDataId",
                table: "Material_HighCycleFatigueDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_HighSpeedStrechDataDetails_MaterialTrialDataId",
                table: "Material_HighSpeedStrechDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_HighSpeedStrechDataDetailStressStrainExtends_HighS~",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends",
                column: "HighSpeedStrechDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_HighSpeedStrechDataDetailStressStrains_HighSpeedSt~",
                table: "Material_HighSpeedStrechDataDetailStressStrains",
                column: "HighSpeedStrechDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_HydrogenInducedDelayedFractureDataDetailItems_Hydr~",
                table: "Material_HydrogenInducedDelayedFractureDataDetailItems",
                column: "HydrogenInducedDelayedFractureDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_HydrogenInducedDelayedFractureDataDetails_Material~",
                table: "Material_HydrogenInducedDelayedFractureDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_LowCycleFatigueDataDetailItems_LowCycleFatigueData~",
                table: "Material_LowCycleFatigueDataDetailItems",
                column: "LowCycleFatigueDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_LowCycleFatigueDataDetails_MaterialTrialDataId",
                table: "Material_LowCycleFatigueDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_Materials_ManufactoryId",
                table: "Material_Materials",
                column: "ManufactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_Materials_TypicalPartId",
                table: "Material_Materials",
                column: "TypicalPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaterialTrialDatas_MaterialTrialId",
                table: "Material_MaterialTrialDatas",
                column: "MaterialTrialId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaterialTrials_MaterialId",
                table: "Material_MaterialTrials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaterialTrials_TrialId",
                table: "Material_MaterialTrials",
                column: "TrialId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_MetallographicDataDetails_MaterialTrialDataId",
                table: "Material_MetallographicDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PaintingDataDetailAdhesionItems_PaintingDataDetail~",
                table: "Material_PaintingDataDetailAdhesionItems",
                column: "PaintingDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PaintingDataDetailDampHeatItems_PaintingDataDetail~",
                table: "Material_PaintingDataDetailDampHeatItems",
                column: "PaintingDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PaintingDataDetailElectrophoreticItems_PaintingDat~",
                table: "Material_PaintingDataDetailElectrophoreticItems",
                column: "PaintingDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PaintingDataDetailHardnessItems_PaintingDataDetail~",
                table: "Material_PaintingDataDetailHardnessItems",
                column: "PaintingDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PaintingDataDetailHitResistanceItems_PaintingDataD~",
                table: "Material_PaintingDataDetailHitResistanceItems",
                column: "PaintingDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PaintingDataDetailMembraneWeightItems_PaintingData~",
                table: "Material_PaintingDataDetailMembraneWeightItems",
                column: "PaintingDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PaintingDataDetailPhosphatingItems_PaintingDataDet~",
                table: "Material_PaintingDataDetailPhosphatingItems",
                column: "PaintingDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PaintingDataDetailPRatioItems_PaintingDataDetailId",
                table: "Material_PaintingDataDetailPRatioItems",
                column: "PaintingDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PaintingDataDetailRoughnessItems_PaintingDataDetai~",
                table: "Material_PaintingDataDetailRoughnessItems",
                column: "PaintingDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PaintingDataDetails_MaterialTrialDataId",
                table: "Material_PaintingDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PhysicalPerformanceDataDetails_MaterialTrialDataId",
                table: "Material_PhysicalPerformanceDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PhysicalPerformanceDataDetailThermalConductivitys_~",
                table: "Material_PhysicalPerformanceDataDetailThermalConductivitys",
                column: "PhysicalPerformanceDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PhysicalPerformanceDataDetailThermalExpansions_Phy~",
                table: "Material_PhysicalPerformanceDataDetailThermalExpansions",
                column: "PhysicalPerformanceDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_ProhibitedSubstanceDataDetails_MaterialTrialDataId",
                table: "Material_ProhibitedSubstanceDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_ReboundDataDetailItem2s_ReboundDataDetailId",
                table: "Material_ReboundDataDetailItem2s",
                column: "ReboundDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_ReboundDataDetailItem3s_ReboundDataDetailId",
                table: "Material_ReboundDataDetailItem3s",
                column: "ReboundDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_ReboundDataDetailItems_ReboundDataDetailId",
                table: "Material_ReboundDataDetailItems",
                column: "ReboundDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_ReboundDataDetails_MaterialTrialDataId",
                table: "Material_ReboundDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_SecondaryWorkingEmbrittlementDataDetailItems_Secon~",
                table: "Material_SecondaryWorkingEmbrittlementDataDetailItems",
                column: "SecondaryWorkingEmbrittlementDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_SecondaryWorkingEmbrittlementDataDetails_MaterialT~",
                table: "Material_SecondaryWorkingEmbrittlementDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_StaticTensionDataDetailRequirements_MaterialTrialD~",
                table: "Material_StaticTensionDataDetailRequirements",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_StaticTensionDataDetails_MaterialTrialDataId",
                table: "Material_StaticTensionDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_StaticTensionDataDetailStressStrains_StaticTension~",
                table: "Material_StaticTensionDataDetailStressStrains",
                column: "StaticTensionDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_SurfacePropertyCoatingWeights_SurfacePropertyDataD~",
                table: "Material_SurfacePropertyCoatingWeights",
                column: "SurfacePropertyDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_SurfacePropertyDataDetails_MaterialTrialDataId",
                table: "Material_SurfacePropertyDataDetails",
                column: "MaterialTrialDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_SurfacePropertyRoughnesss_SurfacePropertyDataDetai~",
                table: "Material_SurfacePropertyRoughnesss",
                column: "SurfacePropertyDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_Trials_ParentId",
                table: "Material_Trials",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_WeldingDataDetailItems_WeldingDataDetailId",
                table: "Material_WeldingDataDetailItems",
                column: "WeldingDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_WeldingDataDetails_MaterialTrialDataId",
                table: "Material_WeldingDataDetails",
                column: "MaterialTrialDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpAuditLogActions");

            migrationBuilder.DropTable(
                name: "AbpBackgroundJobs");

            migrationBuilder.DropTable(
                name: "AbpClaimTypes");

            migrationBuilder.DropTable(
                name: "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "AbpFeatureValues");

            migrationBuilder.DropTable(
                name: "AbpPermissionGrants");

            migrationBuilder.DropTable(
                name: "AbpRoleClaims");

            migrationBuilder.DropTable(
                name: "AbpSettings");

            migrationBuilder.DropTable(
                name: "AbpTenantConnectionStrings");

            migrationBuilder.DropTable(
                name: "AbpUserClaims");

            migrationBuilder.DropTable(
                name: "AbpUserLogins");

            migrationBuilder.DropTable(
                name: "AbpUserRoles");

            migrationBuilder.DropTable(
                name: "AbpUserTokens");

            migrationBuilder.DropTable(
                name: "IdentityServerApiClaims");

            migrationBuilder.DropTable(
                name: "IdentityServerApiScopeClaims");

            migrationBuilder.DropTable(
                name: "IdentityServerApiSecrets");

            migrationBuilder.DropTable(
                name: "IdentityServerClientClaims");

            migrationBuilder.DropTable(
                name: "IdentityServerClientCorsOrigins");

            migrationBuilder.DropTable(
                name: "IdentityServerClientGrantTypes");

            migrationBuilder.DropTable(
                name: "IdentityServerClientIdPRestrictions");

            migrationBuilder.DropTable(
                name: "IdentityServerClientPostLogoutRedirectUris");

            migrationBuilder.DropTable(
                name: "IdentityServerClientProperties");

            migrationBuilder.DropTable(
                name: "IdentityServerClientRedirectUris");

            migrationBuilder.DropTable(
                name: "IdentityServerClientScopes");

            migrationBuilder.DropTable(
                name: "IdentityServerClientSecrets");

            migrationBuilder.DropTable(
                name: "IdentityServerIdentityClaims");

            migrationBuilder.DropTable(
                name: "IdentityServerPersistedGrants");

            migrationBuilder.DropTable(
                name: "Material_BakeHardeningDataDetailItems");

            migrationBuilder.DropTable(
                name: "Material_BendingDataDetails");

            migrationBuilder.DropTable(
                name: "Material_CementingDataDetails");

            migrationBuilder.DropTable(
                name: "Material_ChemicalElementDataDetails");

            migrationBuilder.DropTable(
                name: "Material_CompressDataDetails");

            migrationBuilder.DropTable(
                name: "Material_DemoUnitProjects");

            migrationBuilder.DropTable(
                name: "Material_DentResistanceDataDetails");

            migrationBuilder.DropTable(
                name: "Material_FlangingClaspDataDetails");

            migrationBuilder.DropTable(
                name: "Material_FLDDataDetailItems");

            migrationBuilder.DropTable(
                name: "Material_HighCycleFatigueDataDetailItems");

            migrationBuilder.DropTable(
                name: "Material_HighSpeedStrechDataDetailStressStrainExtends");

            migrationBuilder.DropTable(
                name: "Material_HighSpeedStrechDataDetailStressStrains");

            migrationBuilder.DropTable(
                name: "Material_HydrogenInducedDelayedFractureDataDetailItems");

            migrationBuilder.DropTable(
                name: "Material_LowCycleFatigueDataDetailItems");

            migrationBuilder.DropTable(
                name: "Material_MetallographicDataDetails");

            migrationBuilder.DropTable(
                name: "Material_PaintingDataDetailAdhesionItems");

            migrationBuilder.DropTable(
                name: "Material_PaintingDataDetailDampHeatItems");

            migrationBuilder.DropTable(
                name: "Material_PaintingDataDetailElectrophoreticItems");

            migrationBuilder.DropTable(
                name: "Material_PaintingDataDetailHardnessItems");

            migrationBuilder.DropTable(
                name: "Material_PaintingDataDetailHitResistanceItems");

            migrationBuilder.DropTable(
                name: "Material_PaintingDataDetailMembraneWeightItems");

            migrationBuilder.DropTable(
                name: "Material_PaintingDataDetailPhosphatingItems");

            migrationBuilder.DropTable(
                name: "Material_PaintingDataDetailPRatioItems");

            migrationBuilder.DropTable(
                name: "Material_PaintingDataDetailRoughnessItems");

            migrationBuilder.DropTable(
                name: "Material_PhysicalPerformanceDataDetailThermalConductivitys");

            migrationBuilder.DropTable(
                name: "Material_PhysicalPerformanceDataDetailThermalExpansions");

            migrationBuilder.DropTable(
                name: "Material_ProhibitedSubstanceDataDetails");

            migrationBuilder.DropTable(
                name: "Material_ReboundDataDetailItem2s");

            migrationBuilder.DropTable(
                name: "Material_ReboundDataDetailItem3s");

            migrationBuilder.DropTable(
                name: "Material_ReboundDataDetailItems");

            migrationBuilder.DropTable(
                name: "Material_SecondaryWorkingEmbrittlementDataDetailItems");

            migrationBuilder.DropTable(
                name: "Material_StaticTensionDataDetailRequirements");

            migrationBuilder.DropTable(
                name: "Material_StaticTensionDataDetailStressStrains");

            migrationBuilder.DropTable(
                name: "Material_SurfacePropertyCoatingWeights");

            migrationBuilder.DropTable(
                name: "Material_SurfacePropertyRoughnesss");

            migrationBuilder.DropTable(
                name: "Material_WeldingDataDetailItems");

            migrationBuilder.DropTable(
                name: "AbpEntityChanges");

            migrationBuilder.DropTable(
                name: "AbpTenants");

            migrationBuilder.DropTable(
                name: "AbpRoles");

            migrationBuilder.DropTable(
                name: "AbpUsers");

            migrationBuilder.DropTable(
                name: "IdentityServerApiScopes");

            migrationBuilder.DropTable(
                name: "IdentityServerClients");

            migrationBuilder.DropTable(
                name: "IdentityServerIdentityResources");

            migrationBuilder.DropTable(
                name: "Material_BakeHardeningDataDetails");

            migrationBuilder.DropTable(
                name: "Material_DemoProjects");

            migrationBuilder.DropTable(
                name: "Material_FLDDataDetails");

            migrationBuilder.DropTable(
                name: "Material_HighCycleFatigueDataDetails");

            migrationBuilder.DropTable(
                name: "Material_HighSpeedStrechDataDetails");

            migrationBuilder.DropTable(
                name: "Material_HydrogenInducedDelayedFractureDataDetails");

            migrationBuilder.DropTable(
                name: "Material_LowCycleFatigueDataDetails");

            migrationBuilder.DropTable(
                name: "Material_PaintingDataDetails");

            migrationBuilder.DropTable(
                name: "Material_PhysicalPerformanceDataDetails");

            migrationBuilder.DropTable(
                name: "Material_ReboundDataDetails");

            migrationBuilder.DropTable(
                name: "Material_SecondaryWorkingEmbrittlementDataDetails");

            migrationBuilder.DropTable(
                name: "Material_StaticTensionDataDetails");

            migrationBuilder.DropTable(
                name: "Material_SurfacePropertyDataDetails");

            migrationBuilder.DropTable(
                name: "Material_WeldingDataDetails");

            migrationBuilder.DropTable(
                name: "AbpAuditLogs");

            migrationBuilder.DropTable(
                name: "IdentityServerApiResources");

            migrationBuilder.DropTable(
                name: "Material_MaterialTrialDatas");

            migrationBuilder.DropTable(
                name: "Material_MaterialTrials");

            migrationBuilder.DropTable(
                name: "Material_Materials");

            migrationBuilder.DropTable(
                name: "Material_Trials");

            migrationBuilder.DropTable(
                name: "Material_Manufactorys");

            migrationBuilder.DropTable(
                name: "Material_TypicalParts");
        }
    }
}
