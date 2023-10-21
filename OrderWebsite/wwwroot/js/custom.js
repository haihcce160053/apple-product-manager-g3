document.getElementById('searchButton').addEventListener('click', function () {
    var searchTerm = document.getElementById('inputMobileSearch').value;
    var encodedSearchTerm = encodeURIComponent(searchTerm);
    window.location.href = '/Shop?search=' + encodedSearchTerm;
});

function closePopup() {
    var popupContainer = document.querySelector(".popup-container");
    popupContainer.style.display = "none";
}







