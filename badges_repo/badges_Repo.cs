using System.Collections.Generic;
using System.Collections.Generic;

namespace BadgeRepo
{
    public class BadgeRepository
    {
        private Dictionary<int, Badge> _badges;
        private int _nextBadgeID; // Keep track of the next available badge ID

        public BadgeRepository()
        {
            _badges = new Dictionary<int, Badge>();
            _nextBadgeID = 1; // Initialize with 1
            SeedBadges();
        }

        private void SeedBadges()
        {
            // Seed badges here
            CreateBadge(new Badge(156, new List<string> { "F1, F2, F3, F4" }, "Admin Badge"));
            CreateBadge(new Badge(285, new List<string> { "F1, F2" }, "Employee Badge"));
        }

        // Create 
        public void CreateBadge(Badge badge)
        {
            _badges.Add(badge.BadgeID, badge);
        }

        // Read
        public Dictionary<int, Badge> GetAllBadges()
        {
            return _badges;
        }

        // Update 
        public void UpdateBadge(int badgeID, List<string> doorAccess)
        {
            if (_badges.ContainsKey(badgeID))
            {
                _badges[badgeID].DoorAccess = doorAccess;
            }
        }

        // Delete a door 
        public void RemoveDoorsFromBadge(int badgeID)
        {
            if (_badges.ContainsKey(badgeID))
            {
                _badges[badgeID].DoorAccess.Clear();
            }
        } 

        //Delete a badge 
        public void RemoveBadge(int badgeID) 
        {
            if(_badges.ContainsKey(badgeID)) 
            {
                _badges.Remove(badgeID) ;
            }
        }
    }
}