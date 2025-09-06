import React, { useState } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Register from "./pages/Register";
import Login from "./pages/Login";
import Sidebar from "./components/Sidebar";
import ChatWindow from "./components/ChatWindow";

function App() {
  const token = localStorage.getItem("token");
  const [activeUser, setActiveUser] = useState(null); // selected user to chat

  return (
    <Routes>
      <Route path="/register" element={<Register />} />
      <Route path="/login" element={<Login />} />
      <Route
        path="/chat"
        element={
          token ? (
            <div style={{ display: "flex", height: "100vh" }}>
              <div style={{ width: "250px", borderRight: "1px solid #ccc" }}>
                <Sidebar onSelectUser={setActiveUser} />
              </div>
              <div style={{ flex: 1, padding: "10px" }}>
                <ChatWindow activeUser={activeUser} />
              </div>
            </div>
          ) : (
            <Navigate to="/login" />
          )
        }
      />
      <Route path="*" element={<Navigate to="/register" />} />
    </Routes>
  );
}

export default App;
