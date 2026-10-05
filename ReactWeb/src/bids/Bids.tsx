import { useState } from "react";
import ApiStatus from "../apiStatus";
import { currencyFormatter } from "../config";
import { useAddBid, useFetchBids } from "../hooks/BidHooks";
import { Bid } from "../types/bids";
import { House } from "../types/House";

type Args = {
  house: House;
};

const Bids = ({ house }: Args) => {
  const { data, status, isSuccess } = useFetchBids(house.id);
  const addBidMutation = useAddBid();

  const emptyBid = {
    id: 0,
    houseId: house.id,
    bidder: "",
    amount: 0,
  };
  const [bid, setBid] = useState<Bid>(emptyBid);

  if (!isSuccess) return <ApiStatus status={status} />;

  const onBidSubmitClick = () => {
    addBidMutation.mutate(bid);
    setBid(emptyBid);
  };

  return (
    <section className="bids" aria-labelledby="bids-heading">
      <h2 id="bids-heading">Bids</h2>
      {data && data.length > 0 ? (
        <table className="table table-sm">
          <thead>
            <tr>
              <th>Bidder</th>
              <th>Amount</th>
            </tr>
          </thead>
          <tbody>
            {data.map((b) => (
              <tr key={b.id}>
                <td>{b.bidder}</td>
                <td>{currencyFormatter.format(b.amount)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <p className="bids__empty">No bids yet. Place the first one below.</p>
      )}
      <div className="bids__form">
        <div>
          <label className="form-label" htmlFor="bidder">
            Your name
          </label>
          <input
            id="bidder"
            className="form-control"
            type="text"
            value={bid.bidder}
            onChange={(e) => setBid({ ...bid, bidder: e.target.value })}
          />
        </div>
        <div>
          <label className="form-label" htmlFor="amount">
            Your bid
          </label>
          <input
            id="amount"
            className="form-control"
            type="number"
            value={bid.amount}
            onChange={(e) =>
              setBid({ ...bid, amount: parseInt(e.target.value) })
            }
          />
        </div>
        <button className="btn btn-primary" onClick={() => onBidSubmitClick()}>
          Place bid
        </button>
      </div>
    </section>
  );
};

export default Bids;
