$(window).ready(function () {

});
const AddFullName = $("#Add_Fullname")
const AddGender = $("#Add_Gender")
const AddCityEl = $("#Add_City")
const AddCountyEl = $("#Add_County")
const AddFullAdress = $("#Add_FullAdress")
const AddContactType = $("#Add_ContactType")

const AddContactValue = $("#Add_ContactValue")

	function PersonAdd(requestBody) {

		let validationResult = addValidator(requestBody);

		if (validationResult.length>0) {

			alert(validationResult[0]);

			return;
    }

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
	if (IsStringNullOrEmpty(requestBody.gender) || requestBody.gender==0) {
		errors.push("Gender is not empty");
	}

	return errors;

}


$("#btnAddWriter").click(function () { 




	const requestBody = {};



	requestBody.nameSurname = AddFullName.val();
	requestBody.gender = AddGender.val();

	PersonAdd(requestBody);
})