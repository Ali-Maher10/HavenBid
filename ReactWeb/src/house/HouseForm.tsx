import { useState } from "react";
import React from "react";
import { House } from "../types/House";
import toBase64 from "../toBase64";
import imageCompression from "browser-image-compression";


type Args ={
    house :House;
    submitted:(house:House) => void;
}

const HouseForm = ({ house, submitted }: Args) => {
    const [houseState, setHouseState] = useState({...house});
    
  const onSubmit: React.MouseEventHandler<HTMLButtonElement> = async (e) => {
    e.preventDefault();
    submitted(houseState);
  };
const onFileSelected = async (
  e: React.ChangeEvent<HTMLInputElement>
): Promise<void> => {
  const file = e.currentTarget.files?.[0];
  if (!file) return;

  try {
    const compressed = await imageCompression(file, {
      maxSizeMB: 1,
      maxWidthOrHeight: 1920,
      useWebWorker: true,
      fileType: "image/jpeg",
      initialQuality: 0.8,
    });

    const photo = await toBase64(compressed);
    setHouseState((current) => ({ ...current, photo }));
  } catch (error) {
    console.error("Could not process the image:", error);
  }
};
      return (
    <form className="house-form">
      <div className="mb-3">
        <label className="form-label" htmlFor="address">Address</label>
        <input
          id="address"
          type="text"
          className="form-control"
          value={houseState.address}
          onChange={(e) =>
            setHouseState({ ...houseState, address: e.target.value })
          }
        />
      </div>
      <div className="mb-3">
        <label className="form-label" htmlFor="country">Country</label>
        <input
          id="country"
          type="text"
          className="form-control"
          value={houseState.country}
          onChange={(e) =>
            setHouseState({ ...houseState, country: e.target.value })
          }
        />
      </div>
      <div className="mb-3">
        <label className="form-label" htmlFor="description">Description</label>
        <textarea
          id="description"
          className="form-control"
          rows={5}
          value={houseState.description}
          onChange={(e) =>
            setHouseState({ ...houseState, description: e.target.value })
          }
        />
      </div>
      <div className="mb-3">
        <label className="form-label" htmlFor="price">Asking price</label>
        <input
          id="price"
          type="number"
          className="form-control"
          value={houseState.price}
          onChange={(e) =>
            setHouseState({ ...houseState, price: parseInt(e.target.value) })
          }
        />
      </div>
      <div className="mb-3">
        <label className="form-label" htmlFor="image">Photo</label>
        <input
          id="image"
          type="file"
          accept="image/*"
          className="form-control"
          onChange={onFileSelected}
        />
        {houseState.photo && (
          <img className="form-preview" src={houseState.photo} alt="Selected house" />
        )}
      </div>
      <button
        className="btn btn-primary"
        disabled={!houseState.address || !houseState.country}
        onClick={onSubmit}
      >
        Save house
      </button>
    </form>
  );
};

export default HouseForm;