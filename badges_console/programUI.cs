using System.Linq;
using System.Collections;
using System.Data;
using System;
using System.Collections.Generic;
using BadgeRepo; 

namespace BadgesConsoleApp 
{
    public class ProgramUI
    {
        private BadgeRepository _badgeRepository ; 
        public ProgramUI() 
        {
            _badgeRepository = new BadgeRepository(); 

            
        } 


        public void Run() 
        { 
            bool continueManaging = true ;
            while (continueManaging) 
            { 
                Console.Clear() ;
                Console.WriteLine("=-=-=-=- Main Menu -=-=-=-="); 
                Console.WriteLine("1 > Create a Badge") ;
                Console.WriteLine("2 > Update a Badge");
                Console.WriteLine("3 > Remove Doors from badge/ delete badge"); 
                Console.WriteLine("4 > List all Badges"); 
                Console.WriteLine("5 > Exit"); 
                string menuSelection = Console.ReadLine();

                switch (menuSelection) 
                {
                    case "1": 
                        CreateBadge(); 
                        break ;
                    case "2": 
                        UpdateBadge(); 
                        break; 
                    case "3": 
                        RemoveDoorsFromBadge(); 
                        break; 
                    case "4": 
                        ListAllBadges(); 
                        break; 
                    case "5": 
                        continueManaging = false;
                        Console.WriteLine("Exiting...") ;
                        break;
                    default: 
                        Console.WriteLine("Invalid choice. Please try again") ;
                        break; 
                } 
            } 
        }

        private void CreateBadge()
        {
        Console.WriteLine("Enter Badge ID"); 
         int badgeID = int.Parse(Console.ReadLine()) ; 
        Console.WriteLine("Enter Badge Name"); 
        string badgeName = Console.ReadLine() ;
        Console.WriteLine("Enter Door Access(comma-separated list as needed)"); 
        List<string> doorAccess = new List<string>(Console.ReadLine().Split(",")) ;
        _badgeRepository.CreateBadge(new Badge(badgeID, doorAccess, badgeName)) ;
        Console.WriteLine("Badge added successfully"); 
        Console.ReadLine() ;
        }
   private void ListAllBadges()
{
    Console.WriteLine("List of all Badges");

    
    Dictionary<int, Badge> allBadges = _badgeRepository.GetAllBadges();

    
    if (allBadges.Count == 0)
    {
        Console.WriteLine("No badges found.");
    }
    else
    {
        
        foreach (var badge in allBadges)
        {
            Console.WriteLine($"Badge ID: {badge.Key}, Name: {badge.Value.BadgeName}");
            Console.WriteLine("Door Access: " + string.Join(", ", badge.Value.DoorAccess));
        }
    }

    Console.ReadLine(); 
}

        private void UpdateBadge()
        {
        Console.WriteLine("Enter Badge ID to update"); 
        int badgeID = int.Parse(Console.ReadLine()) ;
        Console.WriteLine("Enter new Door Access(comma-separated list as needed)"); 
        List<string> doorAccess = new List<string>(Console.ReadLine().Split(",")) ;
        _badgeRepository.UpdateBadge(badgeID, doorAccess) ; 
        Console.WriteLine("Badge Updated successfully") ;
        Console.ReadLine() ;
        }

        private void RemoveDoorsFromBadge()
        { 
        Console.WriteLine("Enter Badge ID to Remove doors from") ;
        int badgeID = int.Parse(Console.ReadLine()) ;
        if (_badgeRepository.GetAllBadges(). ContainsKey(badgeID)) 
        {
            _badgeRepository.RemoveDoorsFromBadge(badgeID) ; 
            Console.WriteLine("Door removed from badge successfully") ;
            Console.WriteLine("Would you like to delete the badge?(yes/no)") ;
            string response = Console.ReadLine() ; 
            if(response.ToLower()== "yes") 
            {
                _badgeRepository.RemoveBadge(badgeID) ;
                Console.WriteLine("Badge Deleted successfully") ;
            } 
            else
            {
                Console.WriteLine("Badge not deleted") ;
            }
        } 
        else 
        {
            Console.WriteLine("Badge not found") ;
        } 
        Console.ReadLine() ;
        }

    }
}