import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../api/axios";
import MessageList from "../components/MessageList";
import MessageInput from "../components/MessageInput";
import UserList from "../components/UserList";

function Chat() {
  const [messages, setMessages] = useState([]);
  const [users, setUsers] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token) navigate("/");

    // Fetch messages
    api.get("/messages", { headers: { Authorization: `Bearer ${token}` } })
      .then((res) => setMessages(res.data))
      .catch(() => alert("Error fetching messages"));

    // Fetch users
    api.get("/users", { headers: { Authorization: `Bearer ${token}` } })
      .then((res) => setUsers(res.data))
      .catch(() => alert("Error fetching users"));
  }, []);

  const sendMessage = async (text) => {
    const token = localStorage.getItem("token");
    try {
      const res = await api.post(
        "/messages",
        { messageText: text },
        { headers: { Authorization: `Bearer ${token}` } }
      );
      setMessages([...messages, res.data]);
    } catch {
      alert("Failed to send message");
    }
  };

  return (
    <div className="chat-container">
      <UserList users={users} />
      <div className="chat-box">
        <MessageList messages={messages} />
        <MessageInput onSend={sendMessage} />
      </div>
    </div>
  );
}

export default Chat;
