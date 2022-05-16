const ApiBaseUrl = "http://localhost:44377/api";

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