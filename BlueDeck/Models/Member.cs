﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BlueDeck.Models.Types;

namespace BlueDeck.Models {
    /// <summary>
    /// Member Entity
    /// </summary>
    public class Member {

        /// <summary>
        /// Gets or sets the Member's Id (PK).
        /// </summary>
        /// <value>
        /// The Member's Id (PK).
        /// </value>
        [Key]
        public int MemberId { get; set; }

        public int RankId { get; set; }
        /// <summary>
        /// Gets or sets the Member's <see cref="Rank"/>.
        /// </summary>
        /// <value>
        /// The <see cref="Rank"/> of the Member
        /// </value>
        [Display(Name = "Rank")]
        [ForeignKey("RankId")]
        public virtual Rank Rank { get; set; }

        /// <summary>
        /// Gets or sets the Member's first name.
        /// </summary>
        /// <value>
        /// The first name of the Member.
        /// </value>
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Member's last name.
        /// </summary>
        /// <value>
        /// The last name of the Member.
        /// </value>
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Member's middle name.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the Member's Departmental Id Number.
        /// </summary>
        /// <value>
        /// The Departmental Id Number of the Member.
        /// </value>
        [Display(Name = "ID Number")]
        public string IdNumber { get; set; }

        public int GenderId { get; set; }
        /// <summary>
        /// Gets or sets the Member's gender.
        /// </summary>
        /// <value>
        /// The Member's gender.
        /// </value>
        /// <seealso cref="T:BlueDeck.Models.Types.MemberGender"/>
        [Display(Name = "Gender")]
        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        public int RaceId { get; set; }
        /// <summary>
        /// Gets or sets the Member's race.
        /// </summary>
        /// <value>
        /// The Member's race.
        /// </value>
        /// <seealso cref="T:BlueDeck.Models.Types.MemberRace"/>
        [Display(Name = "Race")]
        public virtual Race Race { get; set; }

        public int DutyStatusId {get;set;}
        /// <summary>
        /// Gets or sets the Member's duty status.
        /// </summary>
        /// <value>
        /// The Member's race.
        /// </value>
        /// <seealso cref="T:BlueDeck.Models.Types.MemberDutyStatus"/>
        [Display(Name = "Duty Status")]
        [ForeignKey("DutyStatusId")]
        public virtual DutyStatus DutyStatus { get; set; }

        [Display(Name = "Account Status")]
        public int? AppStatusId { get;set; }
        [ForeignKey("AppStatusId")]
        public AppStatus AppStatus { get;set; }
        /// <summary>
        /// Gets or sets the Member's email.
        /// </summary>
        /// <value>
        /// The Member's email.
        /// </value>
        [Display(Name = "Email Address")]
        public string Email {get; set; }

        [Display(Name = "Windows Logon Name")]
        public string LDAPName {get; set;}

        public int? CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        [Display(Name = "Created By")]
        public virtual Member Creator { get; set; }
        [Display(Name = "Date Created")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Date Last Modified")]
        public DateTime LastModified { get; set; }
        public int? LastModifiedById { get; set; }
        [ForeignKey("LastModifiedById")]
        [Display(Name = "Last Modified By")]
        public virtual Member LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the position identifier.
        /// </summary>
        /// <value>
        /// The position identifier.
        /// </value>
        public int PositionId { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Position"/> to which the Member is assigned.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        [Display(Name = "Current Assignment")]
        [ForeignKey("PositionId")]
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the temporary <see cref="Position"/> position identifier.
        /// </summary>
        /// <remarks>
        /// A member can be assigned a Temporary (TDY) position, which allows them to be included in the roster
        /// (but not demographic or staffing) calculations of a second position while preserving their primary position.
        /// </remarks>
        /// <value>
        /// The temporary position identifier.
        /// </value>
        public int? TempPositionId { get; set; }

        /// <summary>
        /// Gets or sets the temporary duty position.
        /// </summary>
        /// <value>
        /// The temporary duty position.
        /// </value>
        [Display(Name = "TDY Assignment")]
        [ForeignKey("TempPositionId")]
        public Position TempPosition {get;set;}


        [Display(Name = "Contact Numbers")]
        public ICollection<ContactNumber> PhoneNumbers { get; set; } = new List<ContactNumber>();

        [Display(Name = "Current Roles")]
        public virtual ICollection<Role> CurrentRoles { get; set; } = new List<Role>();

        public virtual ICollection<Member> CreatedMembers { get; set; } = new List<Member>();
        public virtual ICollection<Position> CreatedPositions { get; set; } = new List<Position>();
        public virtual ICollection<Component> CreatedComponents { get; set; } = new List<Component>();
        public virtual ICollection<Member> LastModifiedMembers { get; set; } = new List<Member>();
        public virtual ICollection<Position> LastModifiedPositions { get; set; } = new List<Position>();
        public virtual ICollection<Component> LastModifiedComponents { get; set; } = new List<Component>();

        public Member()
        {            
        }
        /// <summary>
        /// Gets the formal title form of the Member's name and rank.
        /// </summary>
        /// <remarks>
        /// e.g. "POFC Foo Bar #1234"
        /// </remarks>
        /// <returns>A <see cref="string"/> with the formal display name for the Member</returns>
        public string GetTitleName()
        {
            if(MemberId == 0)
            {
                return "New Member";
            }
            else if(Rank != null && FirstName != null && LastName != null && IdNumber != null)
            {
                return $"{this.Rank.RankShort} {this.FirstName} {this.LastName} #{this.IdNumber}";
            }
            else if (FirstName != null && LastName != null)
            {
                return $"{LastName}, {FirstName}";
            }
            else
            {
                return $"BlueDeck Member #{MemberId}";
            }     
            
        }

        /// <summary>
        /// Gets the Member's name in "LastName, FirstName" format.
        /// </summary>
        /// <returns>A <see cref="string"/> with the Member's "LastName, FirstName"</returns>
        public string GetLastNameFirstName()
        {
            if (!String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(LastName))
            {
                return $"{this.LastName}, {this.FirstName}";
            }
            else
            {
                return "";
            }
            
        }    

        public bool IsComponentAdmin()
        {
            return CurrentRoles.Any(x => x.RoleType.RoleTypeName == "ComponentAdmin");
        }

    }
}

