using System.Collections.Generic;
using WeddingAzure.Models;

namespace WeddingAzure.Factories
{
    public static class AccommodationFactory
    {
        /// <summary>
        /// Get images and descriptions for the wedding party.
        /// Set the text to display for each person here.
        /// </summary>
        public static List<Accommodation> GetAccommodations()
        {
            var travelodge = new Accommodation(
                name: "Travelodge Dorking",
                address: "Reigate Rd, Dorking RH4 1QB, UK",
                phone: "0871 984 6026",
                description: @"Straightforward budget option featuring casual rooms with custom-designed beds, plus free parking.
                We have reserved the full hotel with preferential rates! Book with the below link to access this.",
                link: "https://www.incorporatevenues.com/public/b/1425/"
            );

            var burford = new Accommodation(
                name: "Burford Bridge Hotel",
                address: "At the Foot of Box Hill, Dorking, RH5 6BX",
                phone: null,
                description: @"Mercure Box Hill Burford Bridge Hotel is a 4 - star hotel set in stunning North Downs
                Enjoy the beautiful surroundings coupled with the divine detail of the hotel itself.
                Includes the complimentary outdoor heated swimming pool.",
                link: "http://www.mercure.com/gb/hotel-6635-mercure-box-hill-burford-bridge-hotel/index.shtml"
            );

            var whiteHorse = new Accommodation(
                name:"The White Horse",
                address: "High St, Dorking RH4 1BE, UK",
                phone: "020 7660 0685",
                description: @"The 3-star Mercure Dorking White Horse Hotel has 78 classically decorated bedrooms,
                housed in an 18th century coaching inn, giving the hotel its character and atmospheric charm.",
                link: "http://www.mercure.com/gb/hotel-6637-mercure-dorking-white-horse-hotel/index.shtml"
            );

            var lincolnArms = new Accommodation(
                name: "Lincoln Arms Hotel & Bar",
                address: "Station Approach, Dorking RH4 1TF, UK",
                phone: "01306 882820",
                description: @"The Lincoln Arms is an old station Inn, dating back to 1867, and enjoying a prominent position in the market town of Dorking.
                The Lincoln Arms Inn has 20 en-suite bedrooms, offering accommodation for the budget conscious.",
                link: "http://lincolnarms.co.uk/"
            );

            return new List<Accommodation>
            {
                travelodge,
                //burford, dont write burford
                whiteHorse,
                lincolnArms
            };
        }
    }
}