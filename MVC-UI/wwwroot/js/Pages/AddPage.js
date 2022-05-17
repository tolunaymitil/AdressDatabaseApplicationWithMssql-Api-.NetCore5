$(window).ready(function () {

});
const AddFullName = $("#Add_Fullname");
const AddGender = $("#Add_Gender");
const AddCityEl = $("#Add_City");
const AddCountyEl = $("#Add_County");
const AddFullAdress = $("#Add_FullAdress");
const AddContactType = $("#Add_ContactType");

const AddContactValue = $("#Add_ContactValue");

	function PersonAdd(requestBody) {

		let validationResult = addValidator(requestBody);

		if (validationResult.length>0) {

			alert(validationResult[0]);

			return;
    }

		$.ajax({
			type: "POST",
			url: "https://localhost:44377/api/Person",
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
	if (IsStringNullOrEmpty(requestBody.addresses.city)) {
		errors.push("City is not empty");
	}
	if (IsStringNullOrEmpty(requestBody.addresses.county)) {
		errors.push("County is not empty");
	}
	
	if (IsStringNullOrEmpty(requestBody.gender) || requestBody.gender==0) {
		errors.push("Gender is not empty");

	}
    else {
		requestBody.gender = parseInt(AddGender.val());
    }
	if (IsStringNullOrEmpty(requestBody.addresses.fullAddress) || requestBody.addresses.fullAddress.length < 50 || requestBody.addresses.fullAddress.length>150) {
		errors.push("Full Adress is less than 50 character or more than 150 character");
	}
	if (IsStringNullOrEmpty(requestBody.contacts.contactType) || requestBody.contacts.contactType==0) {
		errors.push("Contact Type is not empty");
	}
    else {
		requestBody.contacts.contactType = parseInt(AddContactType.val());
	}
	if (IsStringNullOrEmpty(requestBody.contacts.contactValue)) {
		errors.push("Contact Value is not empty");
	}
	return errors;

}


$("#btnAddWriter").click(function () { 




	const requestBody = [];



	requestBody.nameSurname = AddFullName.val();
	requestBody.gender = AddGender.val();
	  
	requestBody.addresses = [{
		city: AddCityEl.val(),
		county: AddCountyEl.val(),
		fullAddress: AddFullAdress.val()

	}]


	requestBody.contacts = [{
		contactType: AddContactType.val(),
		contactValue: AddContactValue.val()
    }]
	
	 
	PersonAdd(requestBody);
})