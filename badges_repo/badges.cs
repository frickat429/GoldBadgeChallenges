using System.Collections.Generic;
namespace BadgeRepo
{
    public class Badge 
{
public int BadgeID { get; set; } 
public List<string> DoorAccess { get; set; } 
public String BadgeName { get; set; } 
public Badge(int badgeID, List<string> doorAccess, string badgeName) 
{
    BadgeID = badgeID;
    DoorAccess = doorAccess; 
    BadgeName = badgeName ;
    
}

}

}
