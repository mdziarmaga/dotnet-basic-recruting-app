using System.ComponentModel.DataAnnotations;

namespace MatchDataManager.Api.Models;

public class Team : Entity
{
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(255, ErrorMessage = "Length can't be longer than 255 signs.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Coach name is required.")]
    [MaxLength(255, ErrorMessage = "Length can't be longer than 55 signs.")]
    public string CoachName { get; set; }
}