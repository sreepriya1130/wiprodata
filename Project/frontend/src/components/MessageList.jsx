function MessageList({ messages }) {
  return (
    <div className="messages">
      {messages.map((m, i) => (
        <div key={i} className="message">
          <strong>{m.sender?.displayName || "User"}:</strong> {m.messageText}
        </div>
      ))}
    </div>
  );
}
export default MessageList;
