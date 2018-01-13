using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingAzure.Models;
using WeddingAzure.Services;

namespace WeddingAzure.Factories
{
    public static class WeddingPartyFactory
    {
        /// <summary>
        /// Get images and descriptions for the wedding party.
        /// Set the text to display for each person here.
        /// </summary>
        public static List<WeddingPartyMember> GetWeddingPartyMembers(IImageService imageService)
        {
            //ANDY
            var matt = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "matt.jpg"),
                name: "Matt Sprague",
                role: "Best Man",
                description: @"Matt is Andy's older brother. As a volunteer lifeguard based in Sydney, he enjoys
                swimming in shark infested waters, saving people from shark infested waters, and wearing his awesome red and yellow patrol cap
                so he can be seen in shark infested waters.",
                weddingParty: WeddingParty.Andy);

            var jepps = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "jepps.jpg"),
                name: "Tom Jepps",
                role: "Best Man",
                description: @"Tom met Andy at secondary school and they went travelling together for a year.
                He enjoys rugby, travelling, and changing his point of view during an argument to make sure he wins it.",
                weddingParty: WeddingParty.Andy);

            var will = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "will.jpg"),
                name: "Will Brooke",
                role: "Groomsman",
                description: @"Will met Andy at University where they studied Physics together. 
                He enjoys watching sports, watching films, watching viral videos, watching Southpark, 
                and watching Louis Theroux documentaries.",
                weddingParty: WeddingParty.Andy);

            var sinead = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "sinaed.jpg"),
                name: "Sinéad Walton Brown",
                role: "Groomswoman",
                description: @"Sinéad met Andy in Cambodia and also knows Lizi from university.
                It is through this connection that Andy and Lizi met. She enjoys theatre,
                dancing on inanimate objects, eating raw chicken, and having long conversations about feelings (the 'DMC').",
                weddingParty: WeddingParty.Andy);

            var ben = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "ben.jpg"),
                name: "Ben Anderson",
                role: "Groomsman",
                description: @"Ben met Andy at University where they played rugby together and drank
                copious amounts of cheap lager beer. Ben enjoys pretending to be Scottish, 
                hiding his baby face with a beard, and well built bridges.",
                weddingParty: WeddingParty.Andy);

            var nathan = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "nathan.jpg"),
                name: "Nathan Gornall",
                role: "Groomsman",
                description: @"Nathan is Andy's brother-in-law. He likes playing football, talking about football,
                and betting on football (that's soccer for our American guests).",
                weddingParty: WeddingParty.Andy);

            //LIZI
            var ali = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "ali.jpg"),
                name: "Ali Black",
                role: "Maid of Honour",
                description: @"Ali - aka Baz - is a pigeon.
                Ali met Lizi on the first day of school when they sat next to each other in class.
                Since then they’ve been inseparable, even when they’re oceans apart.
                Ali loves good wine, getting pampered and relaxing in the sun! ",
                weddingParty: WeddingParty.Lizi);

            var hails = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "hails.jpg"),
                name: "Hayley Richardson",
                role: "Maid of Honour",
                description: @"Hayley - aka Hails - is a pigeon.
                Hails and Lizi lived together for many years and Hails taught Lizi many invaluable life skills
                including how to poach an egg. She enjoys running, a good gin & tonic and meeting new dogs.",
                weddingParty: WeddingParty.Lizi);

            var loz = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "loz.jpg"),
                name: "Laura Jenkinson",
                role: "Bridesmaid",
                description: @"Laura - aka Lozzie - is a pigeon.
                Lozzie and Lizi met at school and were the ultimate partners in crime - always getting up to mischief.
                Together they sing a great rendition of “Hero” by Enrique Iglesias and share a true love
                for Game of Thrones. Lozzie enjoys teaching yoga, otters, and a meal comprising potato smilies and spaghetti hoops ",
                weddingParty: WeddingParty.Lizi);

            var hayley = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "hayley.jpg"),
                name: "Hayley Rakitzis",
                role: "Bridesmaid",
                description: @"Hayley - aka Hay - is a pigeon.
                Hay met Lizi at boarding school where they shared a room together and realised: “This. Is. It.”
                She loves decorating, shabby chic furniture and nesting.",
                weddingParty: WeddingParty.Lizi);

            var fi = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "fi.jpg"),
                name: "Fiona Dickinson-Hamer",
                role: "Bridesmaid",
                description: @"Fiona - aka Fi - is a pigeon.
                Fi was Lizi’s first ever friend at The Royal School (they read Mizz magazine together).
                She enjoys telling her husband (Ally) off, organising things and attending things she has organised.",
                weddingParty: WeddingParty.Lizi);

            var dan = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "dan.jpg"),
                name: "Daniel Jeffery",
                role: "Master of Ceremonies",
                description: @"Dan is Lizi’s older brother, and the emcee.
                They met when Lizi was born.
                Dan enjoys cricket, playing the piano and swearing profusely (you have been warned!)
",
                weddingParty: WeddingParty.Lizi);

            var weddingParty = new List<WeddingPartyMember>
            {
                matt,
                jepps,
                sinead,
                will,
                ben,
                nathan,
                ali,
                hails,
                loz,
                hayley,
                fi,
                dan
            };
            return weddingParty;
        }

    }
}