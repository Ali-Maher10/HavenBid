import { Link, useParams } from "react-router-dom";
import ApiStatus from "../apiStatus";
import { useFetchHouse, useDeleteHouse } from "../hooks/HouseHooks";
import { currencyFormatter } from "../config";
import defaultPhoto from "./defaultPhoto";
import Bids from "../bids/Bids";

const HouseDetail = () => {
  const { id } = useParams();
  if (!id) throw Error("House id not found");

  const houseId = parseInt(id, 10);
  const { data, status, isSuccess } = useFetchHouse(houseId);
  const deleteHouseMutation = useDeleteHouse();
  if (!isSuccess) return <ApiStatus status={status} />;
  if (!data) return <div>House id not found</div>;

  return (
    <div className="row g-5">
      <div className="col-lg-6">
        <img
          className="detail-photo"
          src={data.photo ? data.photo : defaultPhoto}
          alt={`Photo of ${data.address}`}
        />
        <div className="detail-actions">
          <Link className="btn btn-outline-sea" to={`/house/edit/${data.id}`}>
            Edit house
          </Link>
          <button
            className="btn btn-danger"
            onClick={() => {
              if (window.confirm("Delete this house? This can't be undone."))
                deleteHouseMutation.mutate(data);
            }}
          >
            Delete house
          </button>
        </div>
      </div>
      <div className="col-lg-6">
        <p className="detail-country">{data.country}</p>
        <h1 className="detail-address">{data.address}</h1>
        <p className="detail-price">{currencyFormatter.format(data.price)}</p>
        <p className="detail-description">{data.description}</p>
        <Bids house={data} />
      </div>
    </div>
  );
};

export default HouseDetail;
