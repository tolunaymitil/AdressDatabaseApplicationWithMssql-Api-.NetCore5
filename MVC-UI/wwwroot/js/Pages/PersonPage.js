$(window).ready(function () {
  GetAllWithPagging();
});
const personTableDomEl = $("#personTable")
const personTableBodyDomEl = $("#personTable tbody")
const searchFullname = $("#search_Fullname");
const searchCitySelectEl = $("#search_City");
const searchCountySelectEl = $("#search_County");
const searchGender = $("#search_Gender");
const searchBirthDate = $("#search_BirthDate");
const searchEmail = $("#search_Email");
const searchPhone = $("#search_Phone");
const searchWhatsapp = $("#search_Whatsapp");
const requestBody = {
  "nameSurname": "",
  "birthDate": "1900-01-01",
  "gender": 0,
    "county": "",
  "contactQuery": [],
  "Email": "",
  "city": "",
  "take": 100,
  "skip": 0
};


function GetAllWithPagging() {

  $.ajax({
    type: "POST",
    url: `${ApiBaseUrl}/api/Person/PersonGetAllWithPaging"`,
    data: JSON.stringify(requestBody),
    contentType: "application/json",
    cache: false,
    success: function (data) {
      console.log(data);
      CreateCitySelectBox(data.cityNames);
      CreateCountySelectBox(data.countyNames);
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
function CreateCountySelectBox(countyNames) {
  searchCountySelectEl.html(`<option value="">Select County</option>`);

  countyNames.forEach(function (item) {
    searchCountySelectEl.append(`
  
                  <option value="${item}">${item}</option>
  
              `);
  })


}
function CreateTable(data) {
  personTableBodyDomEl.html("");
  data.forEach(function (item, index) {
      personTableBodyDomEl.append(GetTable(item, index));
  })
}
function GetTable(item, index) {

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
  if (searchCitySelectEl.val() != undefined) {
    requestBody.city = searchCitySelectEl.val();
  }
  else {
    requestBody.city = 0;
    }
    if (searchCountySelectEl.val() != undefined) {
        requestBody.county = searchCountySelectEl.val();

    }
    else {
        requestBody.county = 0;
    }


  if (IsStringNullOrEmpty(searchEmail.val()) == false) {
    const contactQueryEmail = {
      contactType: 1,
      contactValue: searchEmail.val()
    };

    requestBody.contactQuery = requestBody.contactQuery.filter(f => f.contactType != 1);
    requestBody.contactQuery.push(contactQueryEmail);
  } else {
    requestBody.contactQuery = requestBody.contactQuery.filter(f => f.contactType != 1);
  }

    if (IsStringNullOrEmpty(searchPhone.val()) == false) {
        const contactQueryPhone = {
            contactType: 2,
            contactValue: searchPhone.val()
        };
        requestBody.contactQuery = requestBody.contactQuery.filter(f => f.contactType != 2);
        requestBody.contactQuery.push(contactQueryPhone);

    }
    else {
        requestBody.contactQuery = requestBody.contactQuery.filter(f => f.contactType != 2);
    }

    if (IsStringNullOrEmpty(searchWhatsapp.val()) == false) {
        const contactQueryWhatsapp = {
            contactType: 3,
            contactValue: searchWhatsapp.val()
        };
        requestBody.contactQuery = requestBody.contactQuery.filter(f => f.contactType != 3);
        requestBody.contactQuery.push(contactQueryWhatsapp);

    }
    else {
        requestBody.contactQuery = requestBody.contactQuery.filter(f => f.contactType != 3);
    }


  GetAllWithPagging();
})





$("#search_Deneme").keyup(function () {
  alert($(this).val())

})

$("#search_Btnexit").click(function () {
  alert($(searchFullname).val())
})





