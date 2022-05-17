$(window).ready(function () {

});
const AddFullName = $("#Add_Fullname");
const AddGender = $("#Add_Gender");
const AddHomeCityEl = $("#Add_Home_City");
const AddHomeCountyEl = $("#Add_Home_County");
const AddHomeFullAdress = $("#Add_Home_FullAdress");
const AddContactEmail = $("#Add_ContactEmail");
const AddContactPhone = $("#Add_ContactPhone");
const AddContactWhatsapp = $("#Add_ContactWhatsapp");


const AddContactAccessableCheckedEl = $('input[name=Add_ContactAccessable]:checked');

	function PersonAdd(requestBody) {

		let validationResult = addValidator(requestBody);

		if (validationResult.length>0) {

			alert(validationResult[0]);

			return;
    }
		console.log("requestBody", requestBody, JSON.stringify(requestBody));
		$.ajax({
			type: "POST",
			url: `${ApiBaseUrl}/Person`,
			data: JSON.stringify(requestBody),
			contentType: "application/json",
			cache: false,
			success: function (data) {
				console.log(data);

			 
			},
			error: function (err) {
				console.error(err);
			}

		});

	}



function addValidator(requestBody) {

	let errors = [];


	if (IsStringNullOrEmpty(requestBody.nameSurname)) {
		errors.push("Fullname is not empty");
	}

	//requestBody.addresses.forEach(function (item) {

	//	if (item.addressType==1) {
	//		if (IsStringNullOrEmpty(requestBody.addresses.city)) {
	//			errors.push("City is not empty");
	//		}
	//		if (IsStringNullOrEmpty(requestBody.addresses.county)) {
	//			errors.push("County is not empty");
	//		}

	//		if (IsStringNullOrEmpty(requestBody.gender) || requestBody.gender == 0) {
	//			errors.push("Gender is not empty");

	//		}
 //   }
	//})



	//if (IsStringNullOrEmpty(requestBody.addresses.fullAddress) || requestBody.addresses.fullAddress.length < 50 || requestBody.addresses.fullAddress.length>150) {
	//	errors.push("Full Adress is less than 50 character or more than 150 character");
	//}
	//if (IsStringNullOrEmpty(requestBody.contacts.contactType) || requestBody.contacts.contactType==0) {
	//	errors.push("Contact Type is not empty");
	//}
 //   else {
	//	requestBody.contacts.contactType = parseInt(AddContactType.val());
	//}
	//if (IsStringNullOrEmpty(requestBody.contacts.contactValue)) {
	//	errors.push("Contact Value is not empty");
	//}
	return errors;

}


$("#btnAddWriter").click(function () { 




	const requestBody = {};


	requestBody.nameSurname = AddFullName.val();
	requestBody.gender = parseInt(AddGender.val());

	requestBody.contacts = [];


	let selectedContactType = parseInt(AddContactAccessableCheckedEl.val());

	console.log(AddContactAccessableCheckedEl.val(),selectedContactType)
	//email
	if (IsStringNullOrEmpty(AddContactEmail.val()) == false) {
		let obj = {
			contactType: 1,
			contactValue: AddContactEmail.val(),
			ContactIsAcceessable : selectedContactType == 1 ? true : false
    }
		requestBody.contacts.push(obj);
	}


	//phone
	if (IsStringNullOrEmpty(AddContactPhone.val()) == false) {
		let obj = {
			contactType: 2,
			contactValue: AddContactPhone.val(),
			ContactIsAcceessable : selectedContactType == 2 ? true : false
		}
		requestBody.contacts.push(obj);
	}
	//whatsapp
	if (IsStringNullOrEmpty(AddContactWhatsapp.val()) == false) {
		let obj = {
			contactType: 3,
			contactValue: AddContactWhatsapp.val(),
			ContactIsAcceessable : selectedContactType == 3 ? true : false
		}
		requestBody.contacts.push(obj);
	}

	requestBody.addresses = [];
	requestBody.addresses.push(
		{
			city: AddHomeCityEl.val(),
			county: AddHomeCountyEl.val(),
			fullAddress: AddHomeFullAdress.val(),
			addressType: 1
		},
	);


	 
	PersonAdd(requestBody);
})