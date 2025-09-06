// Function to fetch a random user and show details
function fetchRandomUser() {
  fetch("https://randomuser.me/api/")
    .then(response => response.json())
    .then(data => {
      const user = data.results[0];
      document.getElementById("userCard").innerHTML = `
        <img src="${user.picture.large}" alt="Profile Picture" style="border-radius:50%;margin-top:10px;">
        <h3>${user.name.first} ${user.name.last}</h3>
        <p><b>Email:</b> ${user.email}</p>
        <p><b>Location:</b> ${user.location.city}, ${user.location.country}</p>
      `;
    })
    .catch(error => console.error("Error fetching user:", error));
}
