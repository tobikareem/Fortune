﻿namespace Flight.Model;

/// <summary>
/// An HotelOffer object as returned by the HotelOffers API.
/// <see cref="HotelOffers.get()"/>
/// </summary>
public class HotelOffer : Resource
{

    /// <summary>
    /// Initializes a new instance of the HotelOffer class.
    /// </summary>
    public HotelOffer() { }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the hotel.
    /// </summary>
    /// <value>The hotel.</value>
    public Hotel Hotel { get; set; }

    /// <summary>
    /// Gets or sets the available.
    /// </summary>
    /// <value>The available.</value>
    public bool? Available { get; set; }

    /// <summary>
    /// Gets or sets the offers.
    /// </summary>
    /// <value>The offers.</value>
    public List<Offer> Offers { get; set; }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class Hotel
    {

        /// <summary>
        /// Initializes a new instance of the Hotel class.
        /// </summary>
        public Hotel() { }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the hotel identifier.
        /// </summary>
        /// <value>The hotel identifier.</value>
        public string HotelId { get; set; }

        /// <summary>
        /// Gets or sets the chain code.
        /// </summary>
        /// <value>The chain code.</value>
        public string ChainCode { get; set; }

        /// <summary>
        /// Gets or sets the brand code.
        /// </summary>
        /// <value>The brand code.</value>
        public string BrandCode { get; set; }

        /// <summary>
        /// Gets or sets the dupe identifier.
        /// </summary>
        /// <value>The dupe identifier.</value>
        public string DupeId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public string Rating { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public TextWithLanguageType Description { get; set; }

        /// <summary>
        /// Gets or sets the amenities.
        /// </summary>
        /// <value>The amenities.</value>
        public List<string> Amenities { get; set; }

        /// <summary>
        /// Gets or sets the media.
        /// </summary>
        /// <value>The media.</value>
        public List<MediaUri> Media { get; set; }

        /// <summary>
        /// Gets or sets the city code.
        /// </summary>
        /// <value>The city code.</value>
        public string CityCode { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double? Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double? Longitude { get; set; }

        /// <summary>
        /// Gets or sets the hotel distance.
        /// </summary>
        /// <value>The hotel distance.</value>
        public HotelDistance HotelDistance { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public AddressType Address { get; set; }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>The contact.</value>
        public HotelContact Contact { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class Offer : Resource
    {

        /// <summary>
        /// Initializes a new instance of the Offer class.
        /// </summary>
        public Offer() { }


        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the room quantity.
        /// </summary>
        /// <value>The room quantity.</value>
        public int? RoomQuantity { get; set; }

        /// <summary>
        /// Gets or sets the rate code.
        /// </summary>
        /// <value>The rate code.</value>
        public string RateCode { get; set; }

        /// <summary>
        /// Gets or sets the rate family estimated.
        /// </summary>
        /// <value>The rate family estimated.</value>
        public RateFamily RateFamilyEstimated { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public TextWithLanguageType Description { get; set; }

        /// <summary>
        /// Gets or sets the commission.
        /// </summary>
        /// <value>The commission.</value>
        public Commission Commission { get; set; }

        /// <summary>
        /// Gets or sets the type of the board.
        /// </summary>
        /// <value>The type of the board.</value>
        public string BoardType { get; set; }

        /// <summary>
        /// Gets or sets the room.
        /// </summary>
        /// <value>The room.</value>
        public RoomDetails Room { get; set; }

        /// <summary>
        /// Gets or sets the guest.
        /// </summary>
        /// <value>The guest.</value>
        public Guests Guest { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public HotelPrice Price { get; set; }

        /// <summary>
        /// Gets or sets the policies.
        /// </summary>
        /// <value>The policies.</value>
        public PolicyDetails Policies { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class HotelDistance
    {
        /// <summary>
        /// Initializes a new instance of the HotelDistance class.
        /// </summary>
        public HotelDistance() { }

        /// <summary>
        /// The description.
        /// </summary>
        public string Description;

        /// <summary>
        /// The distance.
        /// </summary>
        public double? Distance;

        /// <summary>
        /// The distance unit.
        /// </summary>
        public string DistanceUnit;
    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class RateFamily
    {

        /// <summary>
        /// Initializes a new instance of the RateFamily class.
        /// </summary>
        public RateFamily() { }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class Commission
    {

        /// <summary>
        /// Initializes a new instance of the Commission class.
        /// </summary>
        public Commission() { }

        /// <summary>
        /// Gets or sets the percentage.
        /// </summary>
        /// <value>The percentage.</value>
        public string Percentage { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public TextWithLanguageType Description { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class RoomDetails
    {

        /// <summary>
        /// Initializes a new instance of the RoomDetails class.
        /// </summary>
        public RoomDetails() { }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the type estimated.
        /// </summary>
        /// <value>The type estimated.</value>
        public EstimatedRoomType TypeEstimated { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public TextWithLanguageType Description { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class EstimatedRoomType
    {

        /// <summary>
        /// Initializes a new instance of the EstimatedRoomType class.
        /// </summary>
        public EstimatedRoomType() { }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the beds.
        /// </summary>
        /// <value>The beds.</value>
        public int? Beds { get; set; }

        /// <summary>
        /// Gets or sets the type of the bed.
        /// </summary>
        /// <value>The type of the bed.</value>
        public string BedType { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class HotelPrice
    {

        /// <summary>
        /// Initializes a new instance of the HotelPrice class.
        /// </summary>
        public HotelPrice() { }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public string Total { get; set; }

        /// <summary>
        /// Gets or sets the base.
        /// </summary>
        /// <value>The base.</value>
        public string Base { get; set; }

        /// <summary>
        /// Gets or sets the taxes.
        /// </summary>
        /// <value>The taxes.</value>
        public List<HotelTax> Taxes { get; set; }

        /// <summary>
        /// Gets or sets the variations.
        /// </summary>
        /// <value>The variations.</value>
        public PriceVariations Variations { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class HotelTax
    {

        /// <summary>
        /// Initializes a new instance of the HotelTax class.
        /// </summary>
        public HotelTax() { }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the percentage.
        /// </summary>
        /// <value>The percentage.</value>
        public string Percentage { get; set; }

        /// <summary>
        /// Gets or sets the included.
        /// </summary>
        /// <value>The included.</value>
        public bool? Included { get; set;}

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the pricing frequency.
        /// </summary>
        /// <value>The pricing frequency.</value>
        public string PricingFrequency { get; set; }

        /// <summary>
        /// Gets or sets the pricing mode.
        /// </summary>
        /// <value>The pricing mode.</value>
        public string PricingMode { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class PriceVariations
    {

        /// <summary>
        /// Initializes a new instance of the PriceVariations> class.
        /// </summary>
        public PriceVariations() { }

        /// <summary>
        /// Gets or sets the average.
        /// </summary>
        /// <value>The average.</value>
        public BaseTotalAmount Average { get; set; }

        /// <summary>
        /// Gets or sets the changes.
        /// </summary>
        /// <value>The changes.</value>
        public List<PriceVariation> Changes { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class PriceVariation
    {

        /// <summary>
        /// Initializes a new instance of the PriceVariation class.
        /// </summary>
        public PriceVariation() { }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or sets the base.
        /// </summary>
        /// <value>The base.</value>
        public string Base { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public string Total { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class BaseTotalAmount
    {

        /// <summary>
        /// Initializes a new instance of the BaseTotalAmount class.
        /// </summary>
        public BaseTotalAmount() { }

        /// <summary>
        /// Gets or sets the base.
        /// </summary>
        /// <value>The base.</value>
        public string Base { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public string Total { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class Guests
    {

        /// <summary>
        /// Initializes a new instance of the Guests class.
        /// </summary>
        public Guests() { }

        /// <summary>
        /// Gets or sets the adults.
        /// </summary>
        /// <value>The adults.</value>
        public int? Adults { get; set; }

        /// <summary>
        /// Gets or sets the child ages.
        /// </summary>
        /// <value>The child ages.</value>
        public List<int?> ChildAges { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class TextWithLanguageType
    {

        /// <summary>
        /// Initializes a new instance of the TextWithLanguageType class.
        /// </summary>
        public TextWithLanguageType() { }

        /// <summary>
        /// Gets or sets the lang.
        /// </summary>
        /// <value>The lang.</value>
        public string Lang { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class MediaUri
    {

        /// <summary>
        /// Initializes a new instance of the MediaURI class.
        /// </summary>
        public MediaUri() { }

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>The URI.</value>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class AddressType
    {

        /// <summary>
        /// Initializes a new instance of the AddressType class.
        /// </summary>
        public AddressType() { }

        /// <summary>
        /// Gets or sets the lines.
        /// </summary>
        /// <value>The lines.</value>
        public List<string> Lines { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>The postal code.</value>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the city.
        /// </summary>
        /// <value>The name of the city.</value>
        public string CityName { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>The country code.</value>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the state code.
        /// </summary>
        /// <value>The state code.</value>
        public string StateCode { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class HotelContact
    {

        /// <summary>
        /// Initializes a new instance of the HotelContacs class.
        /// </summary>
        public HotelContact() { }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>The fax.</value>
        public string Fax { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class PolicyDetails
    {

        /// <summary>
        /// Initializes a new instance of the PolicyDetails class.
        /// </summary>
        public PolicyDetails() { }

        /// <summary>
        /// Gets or sets the guarantee.
        /// </summary>
        /// <value>The guarantee.</value>
        public GuaranteePolicy Guarantee { get; set; }

        /// <summary>
        /// Gets or sets the deposit.
        /// </summary>
        /// <value>The deposit.</value>
        public GuaranteePolicy Deposit { get; set; }

        /// <summary>
        /// Gets or sets the prepay.
        /// </summary>
        /// <value>The prepay.</value>
        public GuaranteePolicy Prepay { get; set; }

        /// <summary>
        /// Gets or sets the hold time.
        /// </summary>
        /// <value>The hold time.</value>
        public GuaranteePolicy HoldTime { get; set; }

        /// <summary>
        /// Gets or sets the cancellation.
        /// </summary>
        /// <value>The cancellation.</value>
        public CancellationPolicy Cancellation { get; set; }

        /// <summary>
        /// Gets or sets the check in out.
        /// </summary>
        /// <value>The check in out.</value>
        public CheckInOutPolicy CheckInOut { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class GuaranteePolicy
    {

        /// <summary>
        /// Initializes a new instance of the GuaranteePolicy class.
        /// </summary>
        public GuaranteePolicy() { }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the deadline.
        /// </summary>
        /// <value>The deadline.</value>
        public string Deadline { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public TextWithLanguageType Description { get; set; }

        /// <summary>
        /// Gets or sets the accepted payments.
        /// </summary>
        /// <value>The accepted payments.</value>
        public PaymentPolicy AcceptedPayments { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class CancellationPolicy
    {

        /// <summary>
        /// Initializes a new instance of the CancellationPolicy class.
        /// </summary>
        public CancellationPolicy() { }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the number of nights.
        /// </summary>
        /// <value>The number of nights.</value>
        public int? NumberOfNights { get; set; }

        /// <summary>
        /// Gets or sets the percentage.
        /// </summary>
        /// <value>The percentage.</value>
        public string Percentage { get; set; }

        /// <summary>
        /// Gets or sets the deadline.
        /// </summary>
        /// <value>The deadline.</value>
        public string Deadline { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public TextWithLanguageType Description { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class PaymentPolicy
    {

        /// <summary>
        /// Initializes a new instance of the PaymentPolicy class.
        /// </summary>
        public PaymentPolicy() { }

        /// <summary>
        /// Gets or sets the credit cards.
        /// </summary>
        /// <value>The credit cards.</value>
        public List<string> CreditCards { get; set; }
           
        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>The method.</value>
        public string Method { get; set; }

    }

    /// <summary>
    /// An HotelOffer-related object as returned by the HotelOffers API.
    /// <see cref="HotelOffers.get()"/>
    /// </summary>
    public class CheckInOutPolicy
    {

        /// <summary>
        /// Initializes a new instance of the CheckInOutPolicy class.
        /// </summary>
        public CheckInOutPolicy() { }

        /// <summary>
        /// Gets or sets the check in.
        /// </summary>
        /// <value>The check in.</value>
        public string CheckIn { get; set; }

        /// <summary>
        /// Gets or sets the check in description.
        /// </summary>
        /// <value>The check in description.</value>
        public TextWithLanguageType CheckInDescription { get; set; }

        /// <summary>
        /// Gets or sets the check out.
        /// </summary>
        /// <value>The check out.</value>
        public string CheckOut { get; set; }

        /// <summary>
        /// Gets or sets the check out description.
        /// </summary>
        /// <value>The check out description.</value>
        public TextWithLanguageType CheckOutDescription { get; set; }

    }

}