$(window).ready(function () {
  GetAllWithPagging();
});
const personTableDomEl = $("#personTable")
const personTableBodyDomEl = $("#personTable tbody")
const searchFullname = $("#search_Fullname");
const searchCitySelectEl = $("#search_City");
const searchGender = $("#search_Gender");
const searchBirthDate = $("#search_BirthDate");

const requestBody = {
  "nameSurname": "",
  "birthDate": "1900-01-01",
  "gender": 0,
  "contactQuery": [],
  "addressCity": "",
  "take": 100,
  "skip": 0
};
function GetAllWithPagging() {



  $.ajax({
    type: "POST",
    url: "http://localhost:5001/api/person/PersonGetAllWithPaging",
    data: JSON.stringify(requestBody),
    contentType: "application/json",
    cache: false,
    success: function (data) {
      console.log(data);
      CreateCitySelectBox(data.cityNames);
      CreateTable(data.rows);
    },
    error: function (err) {
      console.error(err);
    }

  });
}

function CreateCitySelectBox(cityNames) {
  searchCitySelectEl.html(`<option value="">Select City</option>`);

  cityNames.forEach(function (item) {
    searchCitySelectEl.append(` 

                <option value="${item}">${item}</option>

            `);
  })


}
function CreateTable(data) {
  personTableBodyDomEl.html("");
  data.forEach(function (item, index) {
    personTableBodyDomEl.append(GetTRTAG(item, index));
  })
}
function GetTRTAG(item, index) {

  let birtDate = new Date(item.birthDate);
  index++;
  return ` <tr>
            <th scope="row">${index}</th>
            
            <td>${item.nameSurname}</td>
            <td>${birtDate.toLocaleDateString()}</td>
            <td>${item.gender == 1 ? "Erkek" : "Kadın"}</td>
            <td><button class="btn btn-primary">Click Show</button></td>
            <td><button class="btn btn-primary">Click Show</button></td>
            <td><button class="btn btn-danger">Click Delete</button></td>
        </tr>`;
}

$("#takePersonTableItem").change(function () {
  if ($(this).val() == null || $(this).val() == "" || $(this).val() == undefined) {
    return;
  }
  requestBody.take = parseInt($(this).val());
  console.log(requestBody);
  GetAllWithPagging();
})

$("#search_Btn").click(function () {
  if (IsStringNullOrEmpty(searchFullname.val()) == false) {
    requestBody.nameSurname = searchFullname.val();
  } else {
    requestBody.nameSurname = "";
  }


  if (searchGender.val() != "0") {
    requestBody.gender = parseInt(searchGender.val());
  }
  else {
    requestBody.gender = 0;
  }

  if (IsNullOrUndefined(searchBirthDate.val()) == false && searchBirthDate.val() == "1900-01-01") {
    requestBody.birthDate = searchBirthDate.val();
  } else {
    requestBody.birthDate = "1900-01-01";
  }


  GetAllWithPagging();
})

function IsStringNullOrEmpty(value) {

  if (value == "" || value == undefined || value == null) {
    return true;
  }
  return false;
}
function IsNullOrUndefined(value) {

  if (value == undefined || value == null) {
    return true;
  }
  return false;
}