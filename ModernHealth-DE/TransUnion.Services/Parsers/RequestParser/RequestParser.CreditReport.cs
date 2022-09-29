using System.Collections.Generic;
using System.Text.RegularExpressions;
using DecisionEngine.TunaService.Request;
using DecisionEngine.TunaService.Request.Model;

namespace DecisionEngine.Services.Parsers
{
    public partial class RequestParser
    {
        public static TunaService.Request.CreditReportRequest CreateCreditReportRequest(DecisionEngine.Services.Models.Request.CreditReportRequest request, TransUnionSettings settings)
        {
            //Log initial inputs all arguments

            //Construct Address Object from user object
            //Use Install-Package AddressParser nuget package for addressparser.

            USAddress.AddressParseResult addressObj = null;
            var address = request.Address;

            if (!string.IsNullOrEmpty(address.StreetName) && !string.IsNullOrEmpty(address.City) && !string.IsNullOrEmpty(address.State) && !string.IsNullOrEmpty(address.ZipCode))
            {
                addressObj = new USAddress.AddressParser().ParseAddress($"{address.StreetName}, {address.City}, {address.State} {address.ZipCode}");
            }

            Street street = null;
            if (addressObj != null && !string.IsNullOrEmpty(addressObj.Number) && !string.IsNullOrEmpty(addressObj.Predirectional)
                && !string.IsNullOrEmpty(addressObj.Street) && !string.IsNullOrEmpty(addressObj.Suffix))
            {
                street = new Street
                {
                    name = addressObj.Street,
                    number = addressObj.Number,
                    preDirectional = addressObj.Predirectional,
                    type = addressObj.Suffix
                };
            }
            else
            {
                street = new Street
                {
                    name = address.StreetName
                };
            }

            SubjectRecord subjectRecord = new SubjectRecord
            {
                fileNumber = 1,
                indicative = new Indicative
                {
                    name = new Name
                    {
                        person = new Person
                        {
                            first = request.FirstName,
                            middle = request.MiddleName,
                            last = request.LastName
                        }
                    },
                    address = new List<Address>
                    {
                        new Address
                        {
                            status = address.AddressStatus ?? "current",
                            street = street,
                            location = new Location
                            {
                                city = address.City,
                                state = address.State,
                                zipCode = address.ZipCode
                            }
                        }
                    }
                },
                addOnProduct = new List<AddOnProduct>
                {
                    new AddOnProduct
                    {
                        code = "00V60",
                        scoreModelProduct = true
                    },
                    new AddOnProduct  // TruValidate Fraud Alerts
                    {
                        code = "06500",
                        scoreModelProduct = false   
                    },
                    new AddOnProduct   //VantageScore 4.0
                    {
                        code = "001NN",
                        scoreModelProduct = true
                    },
                    new AddOnProduct  //OFAC Name Screen
                    {
                        code = "06800",
                        scoreModelProduct = false
                    },
                    new AddOnProduct  //MLA Search
                    {
                        code = "07051 ",
                        scoreModelProduct = false
                    }
                }
            };

            string ssn = string.IsNullOrEmpty(request.SsnNumber) ? null : Regex.Replace(request.SsnNumber, "[^0-9.]", ""); //take numbers only
            if (!string.IsNullOrEmpty(ssn))
            {
                subjectRecord.indicative.socialSecurity = new SocialSecurity
                {
                    number = ssn.PadLeft(9, '0')
                };
            }

            //if (user.DateOfBirth.HasValue)
            //{
            subjectRecord.indicative.dateOfBirth = request.DateOfBirth?.ToString("YYYY-MM-DD");
            //}

            var creditReportRequest = new CreditReportRequest
            {
                document = "request",
                version = settings.Version,
                transactionControl = new TransactionControl
                {
                    userRefNumber = request.Id,
                    subscriber = new Subscriber
                    {
                        industryCode = settings.IndustryCode,
                        memberCode = settings.MemberCode,
                        password = settings.Password,
                        inquirySubscriberPrefixCode = settings.PrefixCode
                    },
                    options = new Options
                    {
                        contractualRelationship = "individual",
                        country = "us",
                        language = "en",
                        processingEnvironment = settings.ProcessingEnvironment,
                        pointOfSaleIndicator = "none"
                    }
                },
                product = new Product
                {
                    code = settings.ProductCode,
                    subject = new Subject
                    {
                        number = 1,
                        subjectRecord = subjectRecord,
                    },
                    responseInstructions = new ResponseInstructions
                    {
                        returnErrorText = true,
                    },
                    permissiblePurpose = new PermissiblePurpose
                    {
                        inquiryECOADesignator = "individual"
                    }
                }

            };

            return creditReportRequest;
        }

        public static TunaService.Request.CreditReportRequest CreateCerditPullRequest(DecisionEngine.Services.Models.Request.CreditPullRequest request, TransUnionSettings settings)
        {
            //Log initial inputs all arguments

            //Construct Address Object from user object
            //Use Install-Package AddressParser nuget package for addressparser.

            USAddress.AddressParseResult addressObj = null;
            if (!string.IsNullOrEmpty(request.StreetAddress) && !string.IsNullOrEmpty(request.City) && !string.IsNullOrEmpty(request.State) && !string.IsNullOrEmpty(request.ZipCode))
            {
                addressObj = new USAddress.AddressParser().ParseAddress($"{request.StreetAddress}, {request.City}, {request.State} {request.ZipCode}");
            }

            Street street = null;
            if (addressObj != null && !string.IsNullOrEmpty(addressObj.Number) && !string.IsNullOrEmpty(addressObj.Predirectional)
                && !string.IsNullOrEmpty(addressObj.Street) && !string.IsNullOrEmpty(addressObj.Suffix))
            {
                street = new Street
                {
                    name = addressObj.Street,
                    number = addressObj.Number,
                    preDirectional = addressObj.Predirectional,
                    type = addressObj.Suffix
                };
            }
            else
            {
                street = new Street
                {
                    name = request.StreetAddress,
                    unit = new Unit
                    {
                        number = request.UnitNumber
                    }
                };
            }

            SubjectRecord subjectRecord = new SubjectRecord
            {
                fileNumber = 1,
                indicative = new Indicative
                {
                    name = new Name
                    {
                        person = new Person
                        {
                            first = request.FirstName,
                            middle = request.MiddleName,
                            last = request.LastName
                        }
                    },
                    address = new List<Address>
                    {
                        new Address
                        {
                            status =  "current",
                            street = street,
                            location = new Location
                            {
                                city = request.City,
                                state = request.State,
                                zipCode = request.ZipCode
                            }
                        }
                    }
                },
                addOnProduct = new List<AddOnProduct>
                {
                    new AddOnProduct
                    {
                        code = "00V60",
                        scoreModelProduct = true
                    },
                    new AddOnProduct  // TruValidate Fraud Alerts
                    {
                        code = "06500",
                        scoreModelProduct = false
                    },
                    new AddOnProduct   //VantageScore 4.0
                    {
                        code = "001NN",
                        scoreModelProduct = true
                    },
                    new AddOnProduct  //OFAC Name Screen
                    {
                        code = "06800",
                        scoreModelProduct = false
                    },
                    new AddOnProduct  //MLA Search
                    {
                        code = "07051 ",
                        scoreModelProduct = false
                    }
                }
            };

            var creditReportRequest = new CreditReportRequest
            {
                document = "request",
                version = settings.Version,
                transactionControl = new TransactionControl
                {
                    userRefNumber = "1",
                    subscriber = new Subscriber
                    {
                        industryCode = settings.IndustryCode,
                        memberCode = settings.MemberCode,
                        password = settings.Password,
                        inquirySubscriberPrefixCode = settings.PrefixCode
                    },
                    options = new Options
                    {
                        contractualRelationship = "individual",
                        country = "us",
                        language = "en",
                        processingEnvironment = settings.ProcessingEnvironment,
                        pointOfSaleIndicator = "none"
                    }
                },
                product = new Product
                {
                    code = settings.ProductCode,
                    subject = new Subject
                    {
                        number = 1,
                        subjectRecord = subjectRecord,
                    },
                    responseInstructions = new ResponseInstructions
                    {
                        returnErrorText = true,
                    },
                    permissiblePurpose = new PermissiblePurpose
                    {
                        inquiryECOADesignator = "individual"
                    }
                }

            };

            return creditReportRequest;
        }
    }
}
