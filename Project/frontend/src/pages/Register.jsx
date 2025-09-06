import React, { useState, useEffect } from "react";

const ChatWindow = ({ activeUser }) => {
  const [messages, setMessages] = useState([]);
  const [input, setInput] = useState("");

  useEffect(() => {
    if (activeUser) {
      fetchMessages(activeUser);
    }
  }, [activeUser]);

  const fetchMessages = async (user) => {
    try {
      const token = localStorage.getItem("token");
      const response = await fetch(
        `http://localhost:5180/api/Messages/conversation/${user.id || user.Id || user.userId}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      if (response.ok) {
        const data = await response.json();
        console.log("Fetched conversation:", data);
        setMessages(data);
      } else {
        console.error("Failed to fetch messages", await response.text());
      }
    } catch (err) {
      console.error("Error fetching messages:", err);
    }
  };

  const sendMessage = async () => {
    if (!input || !activeUser) return;

    const receiverId = activeUser.id || activeUser.Id || activeUser.userId;
    const payload = {
      ReceiverId: receiverId,
      Content: input,
    };

    console.log("📤 Sending message payload:", payload);

    try {
      const token = localStorage.getItem("token");
      const response = await fetch("http://localhost:5180/api/Messages/send", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(payload),
      });

      if (response.ok) {
        const newMessage = await response.json();
        console.log("✅ Message saved:", newMessage);
        setMessages((prev) => [...prev, newMessage]);
        setInput("");
      } else {
        console.error("❌ Failed to send message", await response.text());
      }
    } catch (err) {
      console.error("Error sending message:", err);
    }
  };

  return (
    <div className="chat-window">
      <h3>Chat with {activeUser?.name || activeUser?.fullName || "Unknown"}</h3>
      <div className="messages">
        {messages.map((msg) => (
          <div key={msg.id} className="message">
            <strong>{msg.senderName || msg.senderId}:</strong> {msg.content}
          </div>
        ))}
      </div>
      <div className="input-area">
        <input
          type="text"
          placeholder="Type a message..."
          value={input}
          onChange={(e) => setInput(e.target.value)}
        />
        <button onClick={sendMessage}>Send</button>
      </div>
    </div>
  );
};

export default ChatWindow;
