
var ValidForm = function () {

    $("#form_User").validate({
        //== Validate only visible fields
        ignore: ":hidden",

        rules: {
            //UserTypeID: {
            //    required: true,
            //},
            //FirstName: {
            //    required: true,
            //    isAlphanumeric: true
            //},
            DocType: {
                required: true
            },
            DocNo: {
                required: true,
                isAlphanumeric: true,
                minlength: 3,
                maxlength: 20
            },
            DocDate: {
                required: true,
            },
            FromTrdName: {
                minlength: 3,
                maxlength: 100
            },
            FromGSTIN: {
                required: true,
                isAlphanumeric: true,
                minlength: 15,
                maxlength: 15
            },
            //FromStateCode: {
            //    required: true
            //},
            FromAddress1: {
                maxlength: 120
            },
            FromAddress2: {
                maxlength: 120
            },
            FromPlace: {
                maxlength: 50
            },
            FromPincode: {
                required: true,
                isNumeric: true,
                maxlength: 6
            },
            //ToStateCode: {

            //},
            ToTrdName: {
                minlength: 3,
                maxlength: 100
            },
            ToGSTIN: {
                required: true,
                isAlphanumeric: true,
                minlength: 15,
                maxlength: 15
            },
            //ActToStateCode: {
            //    required: true
            //},
            ToAddress1: {
                maxlength: 120,
                isAlphanumeric: true
            },
            ToAddress2: {
                maxlength: 120,
                isAlphanumeric:true
            },
            ToPlace: {
                maxlength: 50
            },
            ToPincode: {
                required: true,
                isNumeric: true,
                maxlength: 6
            },
            //ToStateCode: {

            //},
            TransporterName: {
                minlength:3,
                maxlength: 100
            },
            TransporterId: {
                minlength: 3,
                maxlength: 15,
                isAlphanumeric: true
            },
            TransDistance: {
                required: true,
                isNumeric: true,
                maxlength:4
            },
            TransDocNo: {
                maxlength: 15,
                isAlphanumeric: true
            },
            VehicleNo: {
                minlength: 6,
                maxlength: 10,
                isAlphanumeric: true
            }
        },


        messages: {

            DocType: {
                required: "Please select Document Type.",
            },

            DocNo: {
                required: "Please enter Document No.",
                isAlphanumeric: "Document number contains letters, numbers & underscore only.",
                minlength: "Doc. No. should contain atleast 3 characters.",
                maxlength: "Doc. No. should not exceed 10 characters."
            },
            DocDate: {
                required: "Please select Document date.",
            },
            FromTrdName: {
                minlength: "Name should contain atleast 3 characters.",
                maxlength: "Name should not exceed 100 characters."
            },
            FromGSTIN: {
                required: "Please enter GSTIN",
                isAlphanumeric: "GSTIN should numbers and letters only.",
                minlength: "GSTIN should not be less than 15 characters.",
                maxlength: "GSTIN should not exceed 15 characters."
            },
            //FromStateCode: {
            //    required: true
            //},
            FromAddress1: {
                maxlength: "Address should not exceed 120 characters.",
                isAlphanumeric: "Address contains letters,numbers and underscore only."
            },
            FromAddress2: {
                maxlength: "Street name should not exceed 120 characters.",
                isAlphanumeric: "Street name contains letters,numbers and underscore only."
            },
            FromPlace: {
                maxlength: "Place should not exceed 50 characters."
            },
            FromPincode: {
                required: "Please enter Pincode.",
                isNumeric: "Pincode should contain digits",
                maxlength: "Pinocde should not exceed 6 digits"
            },
            //ToStateCode: {

            //},
            ToTrdName: {
                minlength: "Name should contain atleast 3 characters.",
                maxlength: "Name should not exceed 100 characters."
            },
            ToGSTIN: {
                required: "Please enter GSTIN",
                isAlphanumeric: "GSTIN should numbers and letters only.",
                minlength: "GSTIN should not be less than 15 characters.",
                maxlength: "GSTIN should not exceed 15 characters."
            },
            //ActToStateCode: {
            //    required: "Please select State."
            //},
            ToAddress1: {
                maxlength: "Address should not exceed 120 characters.",
                isAlphanumeric: "Address contains letters,numbers and underscore only."
            },
            ToAddress2: {
                maxlength: "Address should not exceed 120 characters.",
                isAlphanumeric: "Address contains letters,numbers and underscore only."
            },
            ToPlace: {
                maxlength: "Place should not exceed 50 characters."
            },
            ToPincode: {
                required: "Please enter Pincode.",
                isNumeric: "Pincode should contain digits.",
                maxlength: "Pinocde should not exceed 6 digits."
            },
            //ToStateCode: {

            //},
            TransporterName: {
                minlength: "Transporter name should not be less than 3 characters.",
                maxlength: "Transporter name should should not exceed 100 characters."
            },
            TransporterId: {
                minlength: "Transporter Id should not be less than 3 characters.",
                maxlength: "Transporter Id should should not exceed 15 characters.",
                isAlphanumeric: "Transporter Id contains letters,numbers and underscore only."
            },
            TransDistance: {
                required: "Please enter approximate distance.",
                isNumeric: "Distance should be in digits.",
                maxlength: "Max. length is 4 digits."
            },
            TransDocNo: {
                maxlength: "Transporter Doc. No. should should not exceed 15 characters.",
                isAlphanumeric: "Transporter Doc. No. contains letters,numbers and underscore only."
            },
            VehicleNo: {
                minlength:"Vehicle No. should not be less than 3 characters.",
                maxlength: "Vehicle No. shoud not exceed 10 characters.",
                isAlphanumeric: "Vehicle No. contains letters and numbers only."
            },


            FirstName: {
                required: "Please enter your First Name.",
                isAlphanumeric: "First Name contains letters,numbers and underscore only.",
            },
            LastName: {
                required: "Please enter your Last Name.",
                isAlphanumeric: "Last Name contains letters,numbers and underscore only.",
            },
            UserName: {
                required: "Please enter Username.",
                minlength: "Username should contain atleast 8 characters.",
                maxlength: "Username should contain atleast 25 characters.",
            },
            EmailID: {
                required: "Please enter your EmailID.",
                isValidEmailAddress: "Please enter a valid Email ID."
            },
            TransDistance: {
                required: "Please enter your CellPhone",
                isNumeric: "Please enter a valid phone number",
                minlength: "CellPhone should contain atleast 10 characters.",
            },
            
        },
    }).form();
}



//var ValidEmpForm = function () {

//    $("#form_User").validate({
//        //== Validate only visible fields
//        ignore: ":hidden",

//        rules: {
//            UserTypeID: {
//                required: true,
//            },
//            EmpID: {
//                required: true,
//            },
//            FirstName: {
//                required: true,
//                isAlphanumeric: true
//            },
//            LastName: {
//                required: true,
//                isAlphanumeric: true,

//            },
//            UserName: {
//                required: true,
//                minlength: 8,
//                maxlength: 25
//            },
//            EmailID: {
//                required: true,
//                isValidEmailAddress: true,
//            },
//            CellPhone: {
//                required: true,
//                isNumeric: true,
//                minlength: 10
//            }
//        },
//        messages: {
//            FirstName: {
//                required: "Please enter your First Name.",
//                isAlphanumeric: "First Name contains letters,numbers and underscore only.",
//            },
//            LastName: {
//                required: "Please enter your Last Name.",
//                isAlphanumeric: "Last Name contains letters,numbers and underscore only.",
//            },
//            UserName: {
//                required: "Please enter Username.",
//                minlength: "Username should contain atleast 8 characters.",
//                maxlength: "Username should contain atleast 25 characters.",
//            },
//            EmailID: {
//                required: "Please enter your EmailID.",
//                isValidEmailAddress: "Please enter a valid Email ID."
//            },
//            CellPhone: {
//                required: "Please enter your CellPhone",
//                isNumeric: "Please enter a valid phone number",
//                minlength: "CellPhone should contain atleast 10 characters.",
//            }

//        },
//    }).form();
//}