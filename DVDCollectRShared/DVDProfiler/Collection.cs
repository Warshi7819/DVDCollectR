#nullable disable
namespace DVDCollectRShared.DVDProfiler
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Collection
    {

        private CollectionDVD[] dVDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DVD")]
        public CollectionDVD[] DVD
        {
            get
            {
                return this.dVDField;
            }
            set
            {
                this.dVDField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVD
    {

        private string profileTimestampField;

        private string idField;

        private CollectionDVDMediaTypes mediaTypesField;

        private string uPCField;

        private ushort collectionNumberField;

        private CollectionDVDCollectionType collectionTypeField;

        private string titleField;

        private string distTraitField;

        private string originalTitleField;

        private string countryOfOriginField;

        private object countryOfOrigin2Field;

        private object countryOfOrigin3Field;

        private ushort productionYearField;

        private System.DateTime releasedField;

        private bool releasedFieldSpecified;

        private ushort runningTimeField;

        private string ratingSystemField;

        private string ratingField;

        private byte ratingAgeField;

        private byte ratingVariantField;

        private string ratingDetailsField;

        private string caseTypeField;

        private bool caseSlipCoverField;

        private bool caseSlipCoverFieldSpecified;

        private string[] genresField;

        private byte[] regionsField;

        private CollectionDVDFormat formatField;

        private CollectionDVDFeatures featuresField;

        private string[] studiosField;

        private string[] mediaCompaniesField;

        private CollectionDVDAudioTrack[] audioField;

        private string[] subtitlesField;

        private CollectionDVDSRP sRPField;

        private CollectionDVDActors actorsField;

        private CollectionDVDCredits creditsField;

        private string overviewField;

        private string easterEggsField;

        private CollectionDVDDisc[] discsField;

        private string sortTitleField;

        private System.DateTime lastEditedField;

        private byte wishPriorityField;

        private byte countAsField;

        private CollectionDVDPurchaseInfo purchaseInfoField;

        private CollectionDVDReview reviewField;

        private CollectionDVDMediaBanners mediaBannersField;

        private object eventsField;

        private CollectionDVDBoxSet boxSetField;

        private CollectionDVDLoanInfo loanInfoField;

        private object myLinksField;

        private object notesField;

        private object tagsField;

        private CollectionDVDLocks locksField;

        /// <remarks/>
        public string ProfileTimestamp
        {
            get
            {
                return this.profileTimestampField;
            }
            set
            {
                this.profileTimestampField = value;
            }
        }

        /// <remarks/>
        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDMediaTypes MediaTypes
        {
            get
            {
                return this.mediaTypesField;
            }
            set
            {
                this.mediaTypesField = value;
            }
        }

        /// <remarks/>
        public string UPC
        {
            get
            {
                return this.uPCField;
            }
            set
            {
                this.uPCField = value;
            }
        }

        /// <remarks/>
        public ushort CollectionNumber
        {
            get
            {
                return this.collectionNumberField;
            }
            set
            {
                this.collectionNumberField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDCollectionType CollectionType
        {
            get
            {
                return this.collectionTypeField;
            }
            set
            {
                this.collectionTypeField = value;
            }
        }

        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string DistTrait
        {
            get
            {
                return this.distTraitField;
            }
            set
            {
                this.distTraitField = value;
            }
        }

        /// <remarks/>
        public string OriginalTitle
        {
            get
            {
                return this.originalTitleField;
            }
            set
            {
                this.originalTitleField = value;
            }
        }

        /// <remarks/>
        public string CountryOfOrigin
        {
            get
            {
                return this.countryOfOriginField;
            }
            set
            {
                this.countryOfOriginField = value;
            }
        }

        /// <remarks/>
        public object CountryOfOrigin2
        {
            get
            {
                return this.countryOfOrigin2Field;
            }
            set
            {
                this.countryOfOrigin2Field = value;
            }
        }

        /// <remarks/>
        public object CountryOfOrigin3
        {
            get
            {
                return this.countryOfOrigin3Field;
            }
            set
            {
                this.countryOfOrigin3Field = value;
            }
        }

        /// <remarks/>
        public ushort ProductionYear
        {
            get
            {
                return this.productionYearField;
            }
            set
            {
                this.productionYearField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime Released
        {
            get
            {
                return this.releasedField;
            }
            set
            {
                this.releasedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReleasedSpecified
        {
            get
            {
                return this.releasedFieldSpecified;
            }
            set
            {
                this.releasedFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ushort RunningTime
        {
            get
            {
                return this.runningTimeField;
            }
            set
            {
                this.runningTimeField = value;
            }
        }

        /// <remarks/>
        public string RatingSystem
        {
            get
            {
                return this.ratingSystemField;
            }
            set
            {
                this.ratingSystemField = value;
            }
        }

        /// <remarks/>
        public string Rating
        {
            get
            {
                return this.ratingField;
            }
            set
            {
                this.ratingField = value;
            }
        }

        /// <remarks/>
        public byte RatingAge
        {
            get
            {
                return this.ratingAgeField;
            }
            set
            {
                this.ratingAgeField = value;
            }
        }

        /// <remarks/>
        public byte RatingVariant
        {
            get
            {
                return this.ratingVariantField;
            }
            set
            {
                this.ratingVariantField = value;
            }
        }

        /// <remarks/>
        public string RatingDetails
        {
            get
            {
                return this.ratingDetailsField;
            }
            set
            {
                this.ratingDetailsField = value;
            }
        }

        /// <remarks/>
        public string CaseType
        {
            get
            {
                return this.caseTypeField;
            }
            set
            {
                this.caseTypeField = value;
            }
        }

        /// <remarks/>
        public bool CaseSlipCover
        {
            get
            {
                return this.caseSlipCoverField;
            }
            set
            {
                this.caseSlipCoverField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CaseSlipCoverSpecified
        {
            get
            {
                return this.caseSlipCoverFieldSpecified;
            }
            set
            {
                this.caseSlipCoverFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Genre", IsNullable = false)]
        public string[] Genres
        {
            get
            {
                return this.genresField;
            }
            set
            {
                this.genresField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute()]
        [System.Xml.Serialization.XmlArrayItemAttribute("Region", IsNullable = false)]
        public byte[] Regions
        {
            get
            {
                return this.regionsField;
            }
            set
            {
                this.regionsField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDFormat Format
        {
            get
            {
                return this.formatField;
            }
            set
            {
                this.formatField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDFeatures Features
        {
            get
            {
                return this.featuresField;
            }
            set
            {
                this.featuresField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Studio", IsNullable = false)]
        public string[] Studios
        {
            get
            {
                return this.studiosField;
            }
            set
            {
                this.studiosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("MediaCompany", IsNullable = false)]
        public string[] MediaCompanies
        {
            get
            {
                return this.mediaCompaniesField;
            }
            set
            {
                this.mediaCompaniesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("AudioTrack", IsNullable = false)]
        public CollectionDVDAudioTrack[] Audio
        {
            get
            {
                return this.audioField;
            }
            set
            {
                this.audioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Subtitle", IsNullable = false)]
        public string[] Subtitles
        {
            get
            {
                return this.subtitlesField;
            }
            set
            {
                this.subtitlesField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDSRP SRP
        {
            get
            {
                return this.sRPField;
            }
            set
            {
                this.sRPField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDActors Actors
        {
            get
            {
                return this.actorsField;
            }
            set
            {
                this.actorsField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDCredits Credits
        {
            get
            {
                return this.creditsField;
            }
            set
            {
                this.creditsField = value;
            }
        }

        /// <remarks/>
        public string Overview
        {
            get
            {
                return this.overviewField;
            }
            set
            {
                this.overviewField = value;
            }
        }

        /// <remarks/>
        public string EasterEggs
        {
            get
            {
                return this.easterEggsField;
            }
            set
            {
                this.easterEggsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Disc", IsNullable = false)]
        public CollectionDVDDisc[] Discs
        {
            get
            {
                return this.discsField;
            }
            set
            {
                this.discsField = value;
            }
        }

        /// <remarks/>
        public string SortTitle
        {
            get
            {
                return this.sortTitleField;
            }
            set
            {
                this.sortTitleField = value;
            }
        }

        /// <remarks/>
        public System.DateTime LastEdited
        {
            get
            {
                return this.lastEditedField;
            }
            set
            {
                this.lastEditedField = value;
            }
        }

        /// <remarks/>
        public byte WishPriority
        {
            get
            {
                return this.wishPriorityField;
            }
            set
            {
                this.wishPriorityField = value;
            }
        }

        /// <remarks/>
        public byte CountAs
        {
            get
            {
                return this.countAsField;
            }
            set
            {
                this.countAsField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDPurchaseInfo PurchaseInfo
        {
            get
            {
                return this.purchaseInfoField;
            }
            set
            {
                this.purchaseInfoField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDReview Review
        {
            get
            {
                return this.reviewField;
            }
            set
            {
                this.reviewField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDMediaBanners MediaBanners
        {
            get
            {
                return this.mediaBannersField;
            }
            set
            {
                this.mediaBannersField = value;
            }
        }

        /// <remarks/>
        public object Events
        {
            get
            {
                return this.eventsField;
            }
            set
            {
                this.eventsField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDBoxSet BoxSet
        {
            get
            {
                return this.boxSetField;
            }
            set
            {
                this.boxSetField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDLoanInfo LoanInfo
        {
            get
            {
                return this.loanInfoField;
            }
            set
            {
                this.loanInfoField = value;
            }
        }

        /// <remarks/>
        public object MyLinks
        {
            get
            {
                return this.myLinksField;
            }
            set
            {
                this.myLinksField = value;
            }
        }

        /// <remarks/>
        public object Notes
        {
            get
            {
                return this.notesField;
            }
            set
            {
                this.notesField = value;
            }
        }

        /// <remarks/>
        public object Tags
        {
            get
            {
                return this.tagsField;
            }
            set
            {
                this.tagsField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDLocks Locks
        {
            get
            {
                return this.locksField;
            }
            set
            {
                this.locksField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDMediaTypes
    {

        private bool dVDField;

        private bool hDDVDField;

        private bool bluRayField;

        /// <remarks/>
        public bool DVD
        {
            get
            {
                return this.dVDField;
            }
            set
            {
                this.dVDField = value;
            }
        }

        /// <remarks/>
        public bool HDDVD
        {
            get
            {
                return this.hDDVDField;
            }
            set
            {
                this.hDDVDField = value;
            }
        }

        /// <remarks/>
        public bool BluRay
        {
            get
            {
                return this.bluRayField;
            }
            set
            {
                this.bluRayField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDCollectionType
    {

        private bool isPartOfOwnedCollectionField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IsPartOfOwnedCollection
        {
            get
            {
                return this.isPartOfOwnedCollectionField;
            }
            set
            {
                this.isPartOfOwnedCollectionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDFormat
    {

        private string formatAspectRatioField;

        private string formatVideoStandardField;

        private CollectionDVDFormatColorFormat colorFormatField;

        private bool formatLetterBoxField;

        private bool formatPanAndScanField;

        private bool formatFullFrameField;

        private bool format16X9Field;

        private bool formatDualSidedField;

        private bool formatDualLayeredField;

        private CollectionDVDFormatDimensions dimensionsField;

        /// <remarks/>
        public string FormatAspectRatio
        {
            get
            {
                return this.formatAspectRatioField;
            }
            set
            {
                this.formatAspectRatioField = value;
            }
        }

        /// <remarks/>
        public string FormatVideoStandard
        {
            get
            {
                return this.formatVideoStandardField;
            }
            set
            {
                this.formatVideoStandardField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDFormatColorFormat ColorFormat
        {
            get
            {
                return this.colorFormatField;
            }
            set
            {
                this.colorFormatField = value;
            }
        }

        /// <remarks/>
        public bool FormatLetterBox
        {
            get
            {
                return this.formatLetterBoxField;
            }
            set
            {
                this.formatLetterBoxField = value;
            }
        }

        /// <remarks/>
        public bool FormatPanAndScan
        {
            get
            {
                return this.formatPanAndScanField;
            }
            set
            {
                this.formatPanAndScanField = value;
            }
        }

        /// <remarks/>
        public bool FormatFullFrame
        {
            get
            {
                return this.formatFullFrameField;
            }
            set
            {
                this.formatFullFrameField = value;
            }
        }

        /// <remarks/>
        public bool Format16X9
        {
            get
            {
                return this.format16X9Field;
            }
            set
            {
                this.format16X9Field = value;
            }
        }

        /// <remarks/>
        public bool FormatDualSided
        {
            get
            {
                return this.formatDualSidedField;
            }
            set
            {
                this.formatDualSidedField = value;
            }
        }

        /// <remarks/>
        public bool FormatDualLayered
        {
            get
            {
                return this.formatDualLayeredField;
            }
            set
            {
                this.formatDualLayeredField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDFormatDimensions Dimensions
        {
            get
            {
                return this.dimensionsField;
            }
            set
            {
                this.dimensionsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDFormatColorFormat
    {

        private bool clrColorField;

        private bool clrBlackAndWhiteField;

        private bool clrColorizedField;

        private bool clrMixedField;

        /// <remarks/>
        public bool ClrColor
        {
            get
            {
                return this.clrColorField;
            }
            set
            {
                this.clrColorField = value;
            }
        }

        /// <remarks/>
        public bool ClrBlackAndWhite
        {
            get
            {
                return this.clrBlackAndWhiteField;
            }
            set
            {
                this.clrBlackAndWhiteField = value;
            }
        }

        /// <remarks/>
        public bool ClrColorized
        {
            get
            {
                return this.clrColorizedField;
            }
            set
            {
                this.clrColorizedField = value;
            }
        }

        /// <remarks/>
        public bool ClrMixed
        {
            get
            {
                return this.clrMixedField;
            }
            set
            {
                this.clrMixedField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDFormatDimensions
    {

        private bool dim2DField;

        private bool dim3DAnaglyphField;

        private bool dim3DBluRayField;

        /// <remarks/>
        public bool Dim2D
        {
            get
            {
                return this.dim2DField;
            }
            set
            {
                this.dim2DField = value;
            }
        }

        /// <remarks/>
        public bool Dim3DAnaglyph
        {
            get
            {
                return this.dim3DAnaglyphField;
            }
            set
            {
                this.dim3DAnaglyphField = value;
            }
        }

        /// <remarks/>
        public bool Dim3DBluRay
        {
            get
            {
                return this.dim3DBluRayField;
            }
            set
            {
                this.dim3DBluRayField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDFeatures
    {

        private bool featureSceneAccessField;

        private bool featureCommentaryField;

        private bool featureTrailerField;

        private bool featurePhotoGalleryField;

        private bool featureDeletedScenesField;

        private bool featureMakingOfField;

        private bool featureProductionNotesField;

        private bool featureGameField;

        private bool featureDVDROMContentField;

        private bool featureMultiAngleField;

        private bool featureMusicVideosField;

        private bool featureInterviewsField;

        private bool featureStoryboardComparisonsField;

        private bool featureOuttakesField;

        private bool featureClosedCaptionedField;

        private bool featureTHXCertifiedField;

        private bool featurePIPField;

        private bool featureBDLiveField;

        private bool featureBonusTrailersField;

        private bool featureDigitalCopyField;

        private string otherFeaturesField;

        /// <remarks/>
        public bool FeatureSceneAccess
        {
            get
            {
                return this.featureSceneAccessField;
            }
            set
            {
                this.featureSceneAccessField = value;
            }
        }

        /// <remarks/>
        public bool FeatureCommentary
        {
            get
            {
                return this.featureCommentaryField;
            }
            set
            {
                this.featureCommentaryField = value;
            }
        }

        /// <remarks/>
        public bool FeatureTrailer
        {
            get
            {
                return this.featureTrailerField;
            }
            set
            {
                this.featureTrailerField = value;
            }
        }

        /// <remarks/>
        public bool FeaturePhotoGallery
        {
            get
            {
                return this.featurePhotoGalleryField;
            }
            set
            {
                this.featurePhotoGalleryField = value;
            }
        }

        /// <remarks/>
        public bool FeatureDeletedScenes
        {
            get
            {
                return this.featureDeletedScenesField;
            }
            set
            {
                this.featureDeletedScenesField = value;
            }
        }

        /// <remarks/>
        public bool FeatureMakingOf
        {
            get
            {
                return this.featureMakingOfField;
            }
            set
            {
                this.featureMakingOfField = value;
            }
        }

        /// <remarks/>
        public bool FeatureProductionNotes
        {
            get
            {
                return this.featureProductionNotesField;
            }
            set
            {
                this.featureProductionNotesField = value;
            }
        }

        /// <remarks/>
        public bool FeatureGame
        {
            get
            {
                return this.featureGameField;
            }
            set
            {
                this.featureGameField = value;
            }
        }

        /// <remarks/>
        public bool FeatureDVDROMContent
        {
            get
            {
                return this.featureDVDROMContentField;
            }
            set
            {
                this.featureDVDROMContentField = value;
            }
        }

        /// <remarks/>
        public bool FeatureMultiAngle
        {
            get
            {
                return this.featureMultiAngleField;
            }
            set
            {
                this.featureMultiAngleField = value;
            }
        }

        /// <remarks/>
        public bool FeatureMusicVideos
        {
            get
            {
                return this.featureMusicVideosField;
            }
            set
            {
                this.featureMusicVideosField = value;
            }
        }

        /// <remarks/>
        public bool FeatureInterviews
        {
            get
            {
                return this.featureInterviewsField;
            }
            set
            {
                this.featureInterviewsField = value;
            }
        }

        /// <remarks/>
        public bool FeatureStoryboardComparisons
        {
            get
            {
                return this.featureStoryboardComparisonsField;
            }
            set
            {
                this.featureStoryboardComparisonsField = value;
            }
        }

        /// <remarks/>
        public bool FeatureOuttakes
        {
            get
            {
                return this.featureOuttakesField;
            }
            set
            {
                this.featureOuttakesField = value;
            }
        }

        /// <remarks/>
        public bool FeatureClosedCaptioned
        {
            get
            {
                return this.featureClosedCaptionedField;
            }
            set
            {
                this.featureClosedCaptionedField = value;
            }
        }

        /// <remarks/>
        public bool FeatureTHXCertified
        {
            get
            {
                return this.featureTHXCertifiedField;
            }
            set
            {
                this.featureTHXCertifiedField = value;
            }
        }

        /// <remarks/>
        public bool FeaturePIP
        {
            get
            {
                return this.featurePIPField;
            }
            set
            {
                this.featurePIPField = value;
            }
        }

        /// <remarks/>
        public bool FeatureBDLive
        {
            get
            {
                return this.featureBDLiveField;
            }
            set
            {
                this.featureBDLiveField = value;
            }
        }

        /// <remarks/>
        public bool FeatureBonusTrailers
        {
            get
            {
                return this.featureBonusTrailersField;
            }
            set
            {
                this.featureBonusTrailersField = value;
            }
        }

        /// <remarks/>
        public bool FeatureDigitalCopy
        {
            get
            {
                return this.featureDigitalCopyField;
            }
            set
            {
                this.featureDigitalCopyField = value;
            }
        }

        /// <remarks/>
        public string OtherFeatures
        {
            get
            {
                return this.otherFeaturesField;
            }
            set
            {
                this.otherFeaturesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDAudioTrack
    {

        private string audioContentField;

        private string audioFormatField;

        private string audioChannelsField;

        /// <remarks/>
        public string AudioContent
        {
            get
            {
                return this.audioContentField;
            }
            set
            {
                this.audioContentField = value;
            }
        }

        /// <remarks/>
        public string AudioFormat
        {
            get
            {
                return this.audioFormatField;
            }
            set
            {
                this.audioFormatField = value;
            }
        }

        /// <remarks/>
        public string AudioChannels
        {
            get
            {
                return this.audioChannelsField;
            }
            set
            {
                this.audioChannelsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDSRP
    {

        private string denominationTypeField;

        private string denominationDescField;

        private string formattedValueField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DenominationType
        {
            get
            {
                return this.denominationTypeField;
            }
            set
            {
                this.denominationTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DenominationDesc
        {
            get
            {
                return this.denominationDescField;
            }
            set
            {
                this.denominationDescField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FormattedValue
        {
            get
            {
                return this.formattedValueField;
            }
            set
            {
                this.formattedValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDActors
    {

        private object[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Actor", typeof(CollectionDVDActorsActor))]
        [System.Xml.Serialization.XmlElementAttribute("Divider", typeof(CollectionDVDActorsDivider))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDActorsActor
    {

        private string firstNameField;

        private string middleNameField;

        private string lastNameField;

        private ushort birthYearField;

        private string roleField;

        private string creditedAsField;

        private bool voiceField;

        private bool uncreditedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MiddleName
        {
            get
            {
                return this.middleNameField;
            }
            set
            {
                this.middleNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort BirthYear
        {
            get
            {
                return this.birthYearField;
            }
            set
            {
                this.birthYearField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CreditedAs
        {
            get
            {
                return this.creditedAsField;
            }
            set
            {
                this.creditedAsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Voice
        {
            get
            {
                return this.voiceField;
            }
            set
            {
                this.voiceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Uncredited
        {
            get
            {
                return this.uncreditedField;
            }
            set
            {
                this.uncreditedField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDActorsDivider
    {

        private string captionField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Caption
        {
            get
            {
                return this.captionField;
            }
            set
            {
                this.captionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDCredits
    {

        private object[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Credit", typeof(CollectionDVDCreditsCredit))]
        [System.Xml.Serialization.XmlElementAttribute("Divider", typeof(CollectionDVDCreditsDivider))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDCreditsCredit
    {

        private string firstNameField;

        private string middleNameField;

        private string lastNameField;

        private ushort birthYearField;

        private string creditTypeField;

        private string creditSubtypeField;

        private string creditedAsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MiddleName
        {
            get
            {
                return this.middleNameField;
            }
            set
            {
                this.middleNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort BirthYear
        {
            get
            {
                return this.birthYearField;
            }
            set
            {
                this.birthYearField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CreditType
        {
            get
            {
                return this.creditTypeField;
            }
            set
            {
                this.creditTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CreditSubtype
        {
            get
            {
                return this.creditSubtypeField;
            }
            set
            {
                this.creditSubtypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CreditedAs
        {
            get
            {
                return this.creditedAsField;
            }
            set
            {
                this.creditedAsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDCreditsDivider
    {

        private string captionField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Caption
        {
            get
            {
                return this.captionField;
            }
            set
            {
                this.captionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDDisc
    {

        private string descriptionSideAField;

        private string descriptionSideBField;

        private string discIDSideAField;

        private string discIDSideBField;

        private string labelSideAField;

        private string labelSideBField;

        private bool dualLayeredSideAField;

        private bool dualLayeredSideBField;

        private bool dualSidedField;

        private object locationField;

        private object slotField;

        /// <remarks/>
        public string DescriptionSideA
        {
            get
            {
                return this.descriptionSideAField;
            }
            set
            {
                this.descriptionSideAField = value;
            }
        }

        /// <remarks/>
        public string DescriptionSideB
        {
            get
            {
                return this.descriptionSideBField;
            }
            set
            {
                this.descriptionSideBField = value;
            }
        }

        /// <remarks/>
        public string DiscIDSideA
        {
            get
            {
                return this.discIDSideAField;
            }
            set
            {
                this.discIDSideAField = value;
            }
        }

        /// <remarks/>
        public string DiscIDSideB
        {
            get
            {
                return this.discIDSideBField;
            }
            set
            {
                this.discIDSideBField = value;
            }
        }

        /// <remarks/>
        public string LabelSideA
        {
            get
            {
                return this.labelSideAField;
            }
            set
            {
                this.labelSideAField = value;
            }
        }

        /// <remarks/>
        public string LabelSideB
        {
            get
            {
                return this.labelSideBField;
            }
            set
            {
                this.labelSideBField = value;
            }
        }

        /// <remarks/>
        public bool DualLayeredSideA
        {
            get
            {
                return this.dualLayeredSideAField;
            }
            set
            {
                this.dualLayeredSideAField = value;
            }
        }

        /// <remarks/>
        public bool DualLayeredSideB
        {
            get
            {
                return this.dualLayeredSideBField;
            }
            set
            {
                this.dualLayeredSideBField = value;
            }
        }

        /// <remarks/>
        public bool DualSided
        {
            get
            {
                return this.dualSidedField;
            }
            set
            {
                this.dualSidedField = value;
            }
        }

        /// <remarks/>
        public object Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        public object Slot
        {
            get
            {
                return this.slotField;
            }
            set
            {
                this.slotField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDPurchaseInfo
    {

        private CollectionDVDPurchaseInfoPurchasePrice purchasePriceField;

        private object purchasePlaceField;

        private object purchasePlaceTypeField;

        private object purchasePlaceWebsiteField;

        private System.DateTime purchaseDateField;

        private bool receivedAsGiftField;

        private CollectionDVDPurchaseInfoGiftFrom giftFromField;

        /// <remarks/>
        public CollectionDVDPurchaseInfoPurchasePrice PurchasePrice
        {
            get
            {
                return this.purchasePriceField;
            }
            set
            {
                this.purchasePriceField = value;
            }
        }

        /// <remarks/>
        public object PurchasePlace
        {
            get
            {
                return this.purchasePlaceField;
            }
            set
            {
                this.purchasePlaceField = value;
            }
        }

        /// <remarks/>
        public object PurchasePlaceType
        {
            get
            {
                return this.purchasePlaceTypeField;
            }
            set
            {
                this.purchasePlaceTypeField = value;
            }
        }

        /// <remarks/>
        public object PurchasePlaceWebsite
        {
            get
            {
                return this.purchasePlaceWebsiteField;
            }
            set
            {
                this.purchasePlaceWebsiteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime PurchaseDate
        {
            get
            {
                return this.purchaseDateField;
            }
            set
            {
                this.purchaseDateField = value;
            }
        }

        /// <remarks/>
        public bool ReceivedAsGift
        {
            get
            {
                return this.receivedAsGiftField;
            }
            set
            {
                this.receivedAsGiftField = value;
            }
        }

        /// <remarks/>
        public CollectionDVDPurchaseInfoGiftFrom GiftFrom
        {
            get
            {
                return this.giftFromField;
            }
            set
            {
                this.giftFromField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDPurchaseInfoPurchasePrice
    {

        private string denominationTypeField;

        private string denominationDescField;

        private string formattedValueField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DenominationType
        {
            get
            {
                return this.denominationTypeField;
            }
            set
            {
                this.denominationTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DenominationDesc
        {
            get
            {
                return this.denominationDescField;
            }
            set
            {
                this.denominationDescField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FormattedValue
        {
            get
            {
                return this.formattedValueField;
            }
            set
            {
                this.formattedValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDPurchaseInfoGiftFrom
    {

        private string firstNameField;

        private string lastNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDReview
    {

        private byte filmField;

        private byte videoField;

        private byte audioField;

        private byte extrasField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Film
        {
            get
            {
                return this.filmField;
            }
            set
            {
                this.filmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Video
        {
            get
            {
                return this.videoField;
            }
            set
            {
                this.videoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Audio
        {
            get
            {
                return this.audioField;
            }
            set
            {
                this.audioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Extras
        {
            get
            {
                return this.extrasField;
            }
            set
            {
                this.extrasField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDMediaBanners
    {

        private string frontField;

        private string backField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Front
        {
            get
            {
                return this.frontField;
            }
            set
            {
                this.frontField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Back
        {
            get
            {
                return this.backField;
            }
            set
            {
                this.backField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDBoxSet
    {

        private string parentField;

        private string[] contentsField;

        /// <remarks/>
        public string Parent
        {
            get
            {
                return this.parentField;
            }
            set
            {
                this.parentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Content", IsNullable = false)]
        public string[] Contents
        {
            get
            {
                return this.contentsField;
            }
            set
            {
                this.contentsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDLoanInfo
    {

        private bool loanedField;

        /// <remarks/>
        public bool Loaned
        {
            get
            {
                return this.loanedField;
            }
            set
            {
                this.loanedField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CollectionDVDLocks
    {

        private bool entireField;

        private bool coversField;

        private bool titleField;

        private bool mediaTypeField;

        private bool overviewField;

        private bool regionsField;

        private bool genresField;

        private bool sRPField;

        private bool studiosField;

        private bool discInformationField;

        private bool castField;

        private bool crewField;

        private bool featuresField;

        private bool audioTracksField;

        private bool subtitlesField;

        private bool easterEggsField;

        private bool runningTimeField;

        private bool releaseDateField;

        private bool productionYearField;

        private bool caseTypeField;

        private bool videoFormatsField;

        private bool ratingField;

        /// <remarks/>
        public bool Entire
        {
            get
            {
                return this.entireField;
            }
            set
            {
                this.entireField = value;
            }
        }

        /// <remarks/>
        public bool Covers
        {
            get
            {
                return this.coversField;
            }
            set
            {
                this.coversField = value;
            }
        }

        /// <remarks/>
        public bool Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public bool MediaType
        {
            get
            {
                return this.mediaTypeField;
            }
            set
            {
                this.mediaTypeField = value;
            }
        }

        /// <remarks/>
        public bool Overview
        {
            get
            {
                return this.overviewField;
            }
            set
            {
                this.overviewField = value;
            }
        }

        /// <remarks/>
        public bool Regions
        {
            get
            {
                return this.regionsField;
            }
            set
            {
                this.regionsField = value;
            }
        }

        /// <remarks/>
        public bool Genres
        {
            get
            {
                return this.genresField;
            }
            set
            {
                this.genresField = value;
            }
        }

        /// <remarks/>
        public bool SRP
        {
            get
            {
                return this.sRPField;
            }
            set
            {
                this.sRPField = value;
            }
        }

        /// <remarks/>
        public bool Studios
        {
            get
            {
                return this.studiosField;
            }
            set
            {
                this.studiosField = value;
            }
        }

        /// <remarks/>
        public bool DiscInformation
        {
            get
            {
                return this.discInformationField;
            }
            set
            {
                this.discInformationField = value;
            }
        }

        /// <remarks/>
        public bool Cast
        {
            get
            {
                return this.castField;
            }
            set
            {
                this.castField = value;
            }
        }

        /// <remarks/>
        public bool Crew
        {
            get
            {
                return this.crewField;
            }
            set
            {
                this.crewField = value;
            }
        }

        /// <remarks/>
        public bool Features
        {
            get
            {
                return this.featuresField;
            }
            set
            {
                this.featuresField = value;
            }
        }

        /// <remarks/>
        public bool AudioTracks
        {
            get
            {
                return this.audioTracksField;
            }
            set
            {
                this.audioTracksField = value;
            }
        }

        /// <remarks/>
        public bool Subtitles
        {
            get
            {
                return this.subtitlesField;
            }
            set
            {
                this.subtitlesField = value;
            }
        }

        /// <remarks/>
        public bool EasterEggs
        {
            get
            {
                return this.easterEggsField;
            }
            set
            {
                this.easterEggsField = value;
            }
        }

        /// <remarks/>
        public bool RunningTime
        {
            get
            {
                return this.runningTimeField;
            }
            set
            {
                this.runningTimeField = value;
            }
        }

        /// <remarks/>
        public bool ReleaseDate
        {
            get
            {
                return this.releaseDateField;
            }
            set
            {
                this.releaseDateField = value;
            }
        }

        /// <remarks/>
        public bool ProductionYear
        {
            get
            {
                return this.productionYearField;
            }
            set
            {
                this.productionYearField = value;
            }
        }

        /// <remarks/>
        public bool CaseType
        {
            get
            {
                return this.caseTypeField;
            }
            set
            {
                this.caseTypeField = value;
            }
        }

        /// <remarks/>
        public bool VideoFormats
        {
            get
            {
                return this.videoFormatsField;
            }
            set
            {
                this.videoFormatsField = value;
            }
        }

        /// <remarks/>
        public bool Rating
        {
            get
            {
                return this.ratingField;
            }
            set
            {
                this.ratingField = value;
            }
        }
    }


}
