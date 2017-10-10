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
                description: @"Matt is Andy's older brother. He enjoys swimming in very cold water,
                good Indian food, and working out (but only when his wife Chess is watching).",
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
                dancing on inanimate objects and having long conversations about feelings (the 'DMC').",
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
                description: @"Ali is a pigeon. She loves good wine, good conversation, and is always up for an adventure or holiday abroad.",
                weddingParty: WeddingParty.Lizi);

            var hails = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "hails.jpg"),
                name: "Hayley Richardson",
                role: "Maid of Honour",
                description: @"Hayley aka 'hails' is a Pigeon. She enjoys running, 
                interior design, and meeting new dogs.",
                weddingParty: WeddingParty.Lizi);

            var loz = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "loz.jpg"),
                name: "Laura Jenkinson",
                role: "Bridesmaid",
                description: @"Laura aka 'Loz' is a pigeon. She enjoys make-up art, social media, 
                and pretending she's not famous.",
                weddingParty: WeddingParty.Lizi);

            var hayley = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "hayley.jpg"),
                name: "Hayley Rakitzis",
                role: "Bridesmaid",
                description: @"Hayley aka 'little 'un' is a pigeon. She enjoys meeting small dogs, 
                shabby chic furniture, and nesting.",
                weddingParty: WeddingParty.Lizi);

            var fi = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "fi.jpg"),
                name: "Fiona Dickinson-Hamer",
                role: "Bridesmaid",
                description: @"Fi is a pigeon. She enjoys telling Ally off, organising things,
                and attending things she has organised.",
                weddingParty: WeddingParty.Lizi);

            var dan = new WeddingPartyMember(
                imageSrc: imageService.GetImageUri("img", "dan.jpg"),
                name: "Daniel Jeffery",
                role: "Master of Ceremonies",
                description: @"Dan is Lizi's older brother, and our MC. Dan enjoys cricket,
                playing the piano, and swearing profusely.",
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