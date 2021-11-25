import React, { useState } from "react";
import { useForm } from "react-hook-form";

import { createLogEntry } from "./API";

const LogEntryForm = ({ location, onClose }) => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const { register, handleSubmit } = useForm();

  const onSubmit = async (data) => {
    try {
      setLoading(true);
      data.latitude = location.latitude;
      data.longitude = location.longitude;
      await createLogEntry(data);
     // const created = await createLogEntry(data);
     // console.log(created);
      onClose();
    } catch (error) {
      console.error(error);
      setError(error.message);
      setLoading(false);
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="entry-form">
      {error ? <h3 className="error">{error}</h3> : null}
      <label htmlFor="title">Title</label>
      <input {...register("title")} />
      <label htmlFor="comments">Comments</label>
      <input {...register("comments")} />
      <label htmlFor="description">Description</label>
      <input {...register("description")} />
      <label htmlFor="image">Image</label>
      <input {...register("image")} />
      <label htmlFor="visitDate">Visit Date</label>
      <input type="date" {...register("visitDate")} />
      <button disabled={loading}>
        {loading ? "Loading..." : "Create Entry"}
      </button>
    </form>
  );
};

export default LogEntryForm;
