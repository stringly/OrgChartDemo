﻿using System.ComponentModel.DataAnnotations;

namespace OrgChartDemo.Models.Types
{
    /// <summary>
    /// A Class that represents racial demographic group.  Contains properties and methods used in displaying the race of a <see cref="T:OrgChartDemo.Models.Member"/>
    /// </summary>
    public class MemberRace
    {
        /// <summary>
        /// Gets or sets the member race identifier.
        /// </summary>
        /// <value>
        /// The member race identifier.
        /// </value>
        [Key]
        public int MemberRaceId { get; set; }

        /// <summary>
        /// Gets or sets the full name of the member race.
        /// </summary>
        /// <value>
        /// The full name of the member race.
        /// </value>
        public string MemberRaceFullName { get; set; }

        /// <summary>
        /// Gets or sets the race's abbreviation.
        /// </summary>
        /// <value>
        /// The race's abbreviation.
        /// </value>
        public char Abbreviation { get; set; }

    }
}
