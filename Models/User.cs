using System;
using System.Collections.Generic;

namespace BookReaderWebApp.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public string? AvatarUrl { get; set; }

    public string? Bio { get; set; }

    public string? PreferredLanguage { get; set; }

    public string? Timezone { get; set; }

    public bool? EmailVerified { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPremium { get; set; }

    public DateTime? PremiumExpiresAt { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<UserBookmark> UserBookmarks { get; set; } = new List<UserBookmark>();

    public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();

    public virtual ICollection<UserFollow> UserFollows { get; set; } = new List<UserFollow>();

    public virtual ICollection<UserHighlight> UserHighlights { get; set; } = new List<UserHighlight>();

    public virtual ICollection<UserNote> UserNotes { get; set; } = new List<UserNote>();

    public virtual UserPreference? UserPreference { get; set; }

    public virtual ICollection<UserRating> UserRatings { get; set; } = new List<UserRating>();

    public virtual ICollection<UserReadingGoal> UserReadingGoals { get; set; } = new List<UserReadingGoal>();

    public virtual ICollection<UserReadingList> UserReadingLists { get; set; } = new List<UserReadingList>();

    public virtual ICollection<UserReadingProgress> UserReadingProgresses { get; set; } = new List<UserReadingProgress>();

    public virtual ICollection<UserReadingSession> UserReadingSessions { get; set; } = new List<UserReadingSession>();

    public virtual ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();
}
