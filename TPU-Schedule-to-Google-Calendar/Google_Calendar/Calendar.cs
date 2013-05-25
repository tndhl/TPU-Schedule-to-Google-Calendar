using System;
using System.Linq;
using System.Collections.Generic;

using Google.Apis.Services;
using Google.Apis.Util;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace TPU_Schedule_to_Google_Calendar.Google_Calendar
{
    class Calendar
    {
        private CalendarService service = CalendarHelper.getService();

        public List<CalendarListEntry> getCalendarList()
        {
            return (List<CalendarListEntry>) service.CalendarList.List().Fetch().Items;
        }
    }
}
