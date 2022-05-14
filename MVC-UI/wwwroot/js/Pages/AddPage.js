$(window).ready(function () {
	PersonAdd();
});
const AddFullName = $("#Add_Fullname")
const AddGender = $("#Add_Gender")
const AddCityEl = $("#Add_City")
const AddCountyEl = $("#Add_County")
const AddFullAdress = $("#Add_FullAdress")
const AddContactType = $("#Add_ContactType")
const AddContactValue = $("#Add_ContactValue")
 const requestBody = {
	"nameSurname": "",
	"birthDate": "1900-01-01",
	"gender": 0,

	"contactQuery": [],
	"Email": "",
	"addressCity": "",
	"take": 100,
	"skip": 0
};

	function PersonAdd() {

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


$("#btnAddWriter").click(function () { 
	 
	requestBody.nameSurname = AddFullName.val();
})