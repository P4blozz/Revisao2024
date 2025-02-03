document.addEventListener("DOMContentLoaded", function () {
  const modoTemaBtn = document.getElementById("modo-tema");
  const body = document.body;

  if (localStorage.getItem("darkMode") === "enabled") {
    body.classList.add("dark-mode");
    modoTemaBtn.textContent = "🌙";
  } else {
    modoTemaBtn.textContent = "🌞";
  }

  modoTemaBtn.addEventListener("click", function () {
    body.classList.toggle("dark-mode");

    if (body.classList.contains("dark-mode")) {
      localStorage.setItem("darkMode", "enabled");
      modoTemaBtn.textContent = "🌙";
    } else {
      localStorage.setItem("darkMode", "disabled");
      modoTemaBtn.textContent = "🌞";
    }
  });
});
