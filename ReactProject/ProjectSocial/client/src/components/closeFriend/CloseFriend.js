import React from "react";
import "./closeFriend.css";

export default function CloseFriend({ user }) {
  const PF = "http://localhost:3000/assets/";

  return (
    <li className="sidebarFriend">
      <img className="sidebarFriendImg" src={PF + user.profilePicture} alt="" />
      <span className="sidebarFriendName">{user.username}</span>
    </li>
  );
}
