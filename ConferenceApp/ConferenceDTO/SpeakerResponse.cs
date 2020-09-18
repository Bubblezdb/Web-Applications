using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceDTO
{
    public class SpeakerResponse: Speaker
    {
        //Keeps it from returning to the actual model. Instead it goes to the output model. 
        public ICollection<Session> Sessions { get; set; } = new List<Session>();

    }
}
